using System.Collections;

using UnityEngine;

public class LS_Enemy : MonoBehaviour
{
[SerializeField] private GameObject p_point1;
[SerializeField] private GameObject p_point2;   
private Rigidbody2D rb;
private Transform CurrentPoint;

[Header("Enemy Movement")]
[SerializeField] private float MovementSpeed;
[SerializeField] private float MovemntSpeedPatrol;

[Header("Enemy Stats")]
[SerializeField] private GM_Health HealthManager;
[SerializeField] private int Damage;

[Header("Enemy Attack")]
[SerializeField] private float AttackRange;

[Header("Enemy Detection")]
[SerializeField] private float DetectionRange;

[Header ("Animation")]
// [SerializeField] private Animator Animations;

private GameObject Player;

private void Start()
{
    rb = GetComponent<Rigidbody2D>();   
    CurrentPoint = p_point2.transform;
}

private void Update()
{
    if (HealthManager.GetHealth() <= 0)
    {
        // Animations.SetBool("IsDead", true);
        Destroy(gameObject);
    }

    if (Vector2.Distance(transform.position, Player.transform.position) > DetectionRange) 
    {
        Vector2 point = CurrentPoint.position - transform.position;
        if (CurrentPoint == p_point2.transform)
        {
            rb.velocity = new Vector2(MovemntSpeedPatrol, 0);
        }
        else if (CurrentPoint == p_point1.transform)
        {
            rb.velocity = new Vector2(-MovemntSpeedPatrol, 0);
        }

        if (Vector2.Distance(transform.position, CurrentPoint.position) < 0.5f && CurrentPoint == p_point2.transform)
        {
            flip();
            CurrentPoint = p_point1.transform;
        }
        if (Vector2.Distance(transform.position, CurrentPoint.position) < 0.5f && CurrentPoint == p_point1.transform)
        {
            flip();
            CurrentPoint = p_point2.transform;
        }
    } else 
    {
    if (Player == null)
    {
        Player = GameObject.FindGameObjectWithTag("Player"); 
    }
    else
    {
        if (Vector2.Distance(transform.position, Player.transform.position) < DetectionRange)
        {
            if (Vector2.Distance(transform.position, Player.transform.position) < AttackRange)
            {
                // Animations.SetBool("IsAttacking", true);
                // Animations.SetBool("IsWalking", false);
                // Animations.SetBool("IsIdle", false);

                if (Player.transform.position.x > transform.position.x)
                {
                    // transform.localScale = new Vector3(-1, 1, 1);
                }
                else if (Player.transform.position.x < transform.position.x)
                {
                    // transform.localScale = new Vector3(1, 1, 1);
                }

                if (Vector2.Distance(transform.position, Player.transform.position) < 0.5f)
                {
                    Player.GetComponent<GM_Health>().TakeDamage(Damage);                    
                }
            }
            else
            {
                // Animations.SetBool("IsAttacking", false);
                // Animations.SetBool("IsWalking", true);
                // Animations.SetBool("IsIdle", false);
            }
        }
    }
    }
}

private void FixedUpdate()
{
    if (Player == null)
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    else
    {
        if (Vector2.Distance(transform.position, Player.transform.position) < DetectionRange)
        {
            if (Vector2.Distance(transform.position, Player.transform.position) > AttackRange)
            {
                transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, MovementSpeed * Time.deltaTime);
            }
        }
    }

}

private void OnTriggerEnter2D(Collider2D collision)
{
    // if (collision.CompareTag("Player"))
    // {
    //     collision.GetComponent<CharacterMovement>().TakeDamage(Damage);
    // }

    // if (collision.CompareTag("Bullet"))
    // {
    //     Health -= collision.GetComponent<Bullet>().Damage;
    // }
}

private void flip()
{
    Vector3 Scaler = transform.localScale;
    Scaler.x *= -1;
    transform.localScale = Scaler;
}

#if UNITY_EDITOR
private void OnDrawGizmosSelected()
{
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, DetectionRange);

    Gizmos.color = Color.green;
    Gizmos.DrawWireSphere(transform.position, AttackRange);
}

private void OnDrawGizmos()
{
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(p_point1.transform.position, 0.2f);
    Gizmos.DrawWireSphere(p_point2.transform.position, 0.2f);
    
    Gizmos.color = Color.blue;
    Gizmos.DrawLine(p_point1.transform.position, p_point2.transform.position);
}
#endif

}