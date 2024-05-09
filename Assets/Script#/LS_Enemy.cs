using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class LS_Enemy : MonoBehaviour
{
private Rigidbody2D rb;

[Header("Enemy Movement")]
[SerializeField] private float MovementSpeed;

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
}

private void Update()
{
    // if (Health <= 0)
    // {
    //     Destroy(gameObject);
    // }

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
            }
            else
            {
                // Animations.SetBool("IsAttacking", false);
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

#if UNITY_EDITOR
private void OnDrawGizmosSelected()
{
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, DetectionRange);

    Gizmos.color = Color.green;
    Gizmos.DrawWireSphere(transform.position, AttackRange);
}
#endif

}
