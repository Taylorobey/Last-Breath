using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Crawler : InteractableEntityBase
{
    //------------------------------------------------------------------------------------------------------------------
    
    #region Fields and Properties
    
    private const float MagicDistanceWhenItMoves = 1.27f;
    private const float Threshold = 0.5f;

    [SerializeField] [Range(10, 50)] [Tooltip("Damage in seconds dealt to the player")]
    private int crawlerDamage = 20;

    [SerializeField] [Range(0.5f, 3f)] [Tooltip("Time to rest before a new move")]
    private float maxRestTime = 1;
    
    [SerializeField] [Tooltip("Points where the crawler will walk towards to")] 
    private Transform[] points;
    
    
    private float speed = 0;
    [SerializeField] [Range(100, 1000)]private float forcePush;
    private int TargetIndex { get; set; }
    private float RestTime { get; set; }
    
    private bool CanDoDamage { get; set; }
    
    #endregion
    
    //------------------------------------------------------------------------------------------------------------------
    
    #region Unitycallbacks
    
    private void Start()
    {
        transform.position = points[TargetIndex].position;
        UpdateTarget();
        CanDoDamage = true;
    }

    private void Update()
    {
        if(Pushing)
            return;
        
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
                OxygenSystem.Instance.RemoveTime(crawlerDamage);
                StartCoroutine(InvullForSeconds(1));
            }
        }
        
    }

    private IEnumerator InvullForSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        CanDoDamage = true;
    }
    
    //Called by the animator to check the moved distance
    public void MoveAhead()
    {
        if (Pushing)
            return;
        
        var delta = (transform.position - points[TargetIndex].position);
        var distX = Mathf.Abs(delta.x);
        var distY = Mathf.Abs(delta.y);
        
        if (distX > distY)
        {
            if (SpriteRenderer.flipX)
                transform.position = transform.position - new Vector3(MagicDistanceWhenItMoves, 0, 0);
            else
                transform.position = transform.position + new Vector3(MagicDistanceWhenItMoves, 0, 0);    
        } else        
        if (distY > distX)
        {
            if (SpriteRenderer.flipX)
                transform.position = transform.position - new Vector3(0, MagicDistanceWhenItMoves, 0);
            else
                transform.position = transform.position + new Vector3(0, MagicDistanceWhenItMoves, 0);
        }
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
            //I left this part in case we want to add more movement/speed. 
            var amount = speed * Time.deltaTime;
            var final = Vector3.Lerp(transform.position, points[TargetIndex].position, amount);
            Rigidbody.MovePosition(final);
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
    }
    
    #endregion
    
    //------------------------------------------------------------------------------------------------------------------
}
