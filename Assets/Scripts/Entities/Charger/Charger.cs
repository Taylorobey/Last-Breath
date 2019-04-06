using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.Serialization;

public class Charger : InteractableEntityBase
{
    private enum MovementIdleDirection
    {
        Horizontal = 0, Vertical = 1
    }
    
    private enum MovementDirection
    {
        Flipped, NotFlipped
    }
    
    //------------------------------------------------------------------------------------------------------------------
    
    #region Fields and Properties

    #region Charge Configs
    [Header("Charge Configs")][SerializeField] [Range(10, 50)] [Tooltip("Damage in seconds dealt to the player")]
    private int chargerDamage = 40;
    
    [SerializeField] [Range(0, 20)] private float chargeSpeed = 1;
    
    #endregion
    
    #region Idle Configs
    
    private readonly int run = Animator.StringToHash("Run");
    private readonly int idle = Animator.StringToHash("Idle");
    private const float Threshold = 0.3f;
    
    [Header("Idle Configs")]
    [Tooltip("Points where the charger will patrol ")] 
    public Transform[] Points;
    
    [FormerlySerializedAs("maxRestTime")] [SerializeField] [Range(0.5f, 3f)] [Tooltip("Time to rest before a new move")]
    private float idleRestTime = 1;
    
    [SerializeField] [Range(0, 10)] [Tooltip("Speed of the entity")] 
    private float idleSpeed = 0;

    [SerializeField]  [Range(0, 1)]
    private float jumpHeight = 0;

    [SerializeField] [Tooltip("Field of view of the unit")]
    private FieldOfView fieldOfView;
    
    #endregion
    
    #region Properties
    
    private Vector3 TargetPoint { get; set; }
    private int TargetIndex { get; set; }
    private float RestTime { get; set; }
    private bool CanDoDamage { get; set; }
    private bool HasArrived { get; set; }
    private bool Charging { get; set; }
    private float CachedScale { get; set; }
    private MovementDirection Direction => GetDirection();
    private MovementIdleDirection IdleDirection { get; set; }
    
    #endregion
    
    #endregion
    
    //------------------------------------------------------------------------------------------------------------------
    
    #region Unitycallbacks
    
    private void Start()
    {
        transform.position = Points[TargetIndex].position;
        UpdateTarget();
        HasArrived = true;
        CanDoDamage = true;
        CachedScale = transform.localScale.x;
        fieldOfView.OnPlayerFound += OnPlayerFound;

        IdleDirection = GetIdleDirection();
    }

    private void OnDestroy()
    {
        fieldOfView.OnPlayerFound -= OnPlayerFound;
    }


    private void Update()
    {
        if (Charging)
            Charge();
        else
            Idle();
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other == PlayerCollider && CanDoDamage)
        {
            if (CanDoDamage)
            {
                CanDoDamage = false;
                //deals damage to the player
                OxygenSystem.Instance.RemoveTime(chargerDamage);
                StartCoroutine(InvullForSeconds(1));
            }
        }
    }

    private IEnumerator InvullForSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        CanDoDamage = true;
    }
    
    #endregion

    //------------------------------------------------------------------------------------------------------------------
    
    #region Flip and Direction
    
    private void Flip()
    {
        var scale = transform.localScale;
        
        if(Direction == MovementDirection.Flipped)
            scale.x = -CachedScale;
        else 
            scale.x = CachedScale;
        
        transform.localScale = scale;
    }

    private MovementDirection GetDirection()
    {
        return IdleDirection == MovementIdleDirection.Horizontal 
            ? GetHorizontal() : GetVertical();
    }

    private MovementDirection GetVertical()
    {
        return transform.position.y < TargetPoint.y 
            ? MovementDirection.Flipped : MovementDirection.NotFlipped;
    }

    private MovementDirection GetHorizontal()
    {
        return transform.position.x < TargetPoint.x 
            ? MovementDirection.NotFlipped : MovementDirection.Flipped;
    }

    private MovementIdleDirection GetIdleDirection()
    {
        var delta = Points[1].position - Points[0].position;
        var deltaX = Mathf.Abs(delta.x);
        var deltaY = Mathf.Abs(delta.y);
        
        return deltaX >= deltaY ? MovementIdleDirection.Horizontal : MovementIdleDirection.Vertical;
    }

    //called by animator
    public void JumpUp()
    {
        var currentPos = transform.position;
        if (IdleDirection == MovementIdleDirection.Horizontal)
            currentPos.y += jumpHeight;
        else
            currentPos.x += jumpHeight;
        transform.position = currentPos;
    }

    //called by animator
    public void JumpDown()
    {
        var currentPos = transform.position;
        if (IdleDirection == MovementIdleDirection.Horizontal)
            currentPos.y -= jumpHeight;
        else
            currentPos.x -= jumpHeight;
        transform.position = currentPos;
    }
    
    #endregion
    
    //------------------------------------------------------------------------------------------------------------------
    
    #region Idle Behavior

    private void UpdateTarget()
    {
        TargetIndex++;
        if (TargetIndex > Points.Length - 1)
            TargetIndex = 0;

        TargetPoint = Points[TargetIndex].position;
    }

    private float GetDistanceToCurrentTarget()
    {
        return Vector2.Distance(transform.position, TargetPoint);
    }

    
    private void Idle()
    {
        if (GetDistanceToCurrentTarget() > Threshold)
        {
            GoTowardsTarget(idleSpeed);
            
            //------------
            
            if (!HasArrived) 
                return;
            HasArrived = false;
            Animator.Play(run);
        }
        else
            ToArrive();
    }

    private void ToArrive()
    {
        RestTime += Time.deltaTime;
        Rigidbody.MovePosition(Points[TargetIndex].position);
        if (RestTime > idleRestTime)
        {
            RestTime = 0;
            UpdateTarget();
            Flip();
        }

        //------------
        
        if (HasArrived) 
            return;
        HasArrived = true;
        Animator.Play(idle);
    }
    
    #endregion
    
    //------------------------------------------------------------------------------------------------------------------
    
    #region Charge Behavior

    private void OnPlayerFound(Transform obj)
    {
        if (Charging)
            return;

        TargetPoint = IdleDirection == MovementIdleDirection.Horizontal
            ? new Vector3(obj.position.x, transform.position.y, obj.position.z)
            : new Vector3(transform.position.x, obj.position.y, obj.position.z);
        
        Charging = true;
        HasArrived = false;
        Animator.Play(run);
    }

    
    private void Charge()
    {
        var distance = GetDistanceToCurrentTarget();
        if (distance > Threshold)
            GoTowardsTarget(chargeSpeed);
        else
            ToArriveChargePoint();
    }

    private void GoTowardsTarget(float speed)
    {
        var amount = speed * Time.deltaTime;
        var targetPos = TargetPoint;
        var currentPos = transform.position;
        transform.position = Vector3.MoveTowards(currentPos, targetPos, amount);
    }

    private void ToArriveChargePoint()
    {
        RestTime += Time.deltaTime;
        transform.position = TargetPoint;
        if (RestTime > idleRestTime)
        {
            Charging = false;
            //restore previous target
            TargetPoint = Points[TargetIndex].position;
            RestTime = 0;
            Flip();
        }
        
        //------------
        
        if (HasArrived) 
            return;
        
        HasArrived = true;
        Animator.Play(idle);
    }

    #endregion
    
    //------------------------------------------------------------------------------------------------------------------
}
