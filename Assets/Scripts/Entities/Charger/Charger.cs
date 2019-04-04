using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Charger : InteractableEntityBase
{
    //------------------------------------------------------------------------------------------------------------------
    
    #region Fields and Properties

    private readonly int run = UnityEngine.Animator.StringToHash("Run");
    private readonly int idle = UnityEngine.Animator.StringToHash("Idle");
    
    private const float Threshold = 0.1f;

    [SerializeField] [UnityEngine.Range(10, 50)] [Tooltip("Damage in seconds dealt to the player")]
    private int chargerDamage = 20;

    [SerializeField] [UnityEngine.Range(0.5f, 3f)] [Tooltip("Time to rest before a new move")]
    private float maxRestTime = 1;
    
    [SerializeField] [Tooltip("Points where the crawler will walk towards to")] 
    private Transform[] points;
    
    [SerializeField] [Tooltip("Speed of the entity")] 
    private float speed = 0;
    
    [SerializeField]  [Range(0, 1)]
    private float jumpHeight = 0;
    
    private int TargetIndex { get; set; }
    private float RestTime { get; set; }
    
    private bool CanDoDamage { get; set; }
    private bool HasArrived { get; set; }
    
    #endregion
    
    //------------------------------------------------------------------------------------------------------------------
    
    #region Unitycallbacks
    
    private void Start()
    {
        transform.position = points[TargetIndex].position;
        UpdateTarget();
        HasArrived = true;
        CanDoDamage = true;
    }

    private void Update()
    {
        Move();
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
    
    #region Methods
    
    private void FlipLeft()
    {
        SpriteRenderer.flipX = false;
    }

    private void FlipRight()
    {
        SpriteRenderer.flipX = true;
    }
    
    private void UpdateTarget()
    {
        TargetIndex++;
        if (TargetIndex > points.Length - 1)
            TargetIndex = 0;
    }

    private float GetDistanceToCurrentTarget()
    {
        return Vector2.Distance(transform.position, points[TargetIndex].position);
    }

    
    private void Move()
    {
        if (GetDistanceToCurrentTarget() > Threshold)
        {
            var amount = speed * Time.deltaTime;
            var targetPos = points[TargetIndex].position;
            var currentPos = transform.position;
            transform.position = Vector3.MoveTowards(currentPos, targetPos, amount);
            
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
        Rigidbody.MovePosition(points[TargetIndex].position);
        
        if (RestTime > maxRestTime)
        {
            RestTime = 0;
            UpdateTarget();
            if (SpriteRenderer.flipX)
                FlipLeft();
            else
                FlipRight();
        }

        //------------
        
        if (HasArrived) 
            return;
        HasArrived = true;
        Animator.Play(idle);
    }

    public void MoveUp()
    {
        transform.position += new Vector3(0, jumpHeight, 0);
    }

    public void MoveDown()
    {
        transform.position += new Vector3(0, -jumpHeight, 0);
    }
    
    
    #endregion
    
    //------------------------------------------------------------------------------------------------------------------
}
