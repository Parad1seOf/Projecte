using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{

    [SerializeField] private Cooldown cooldown;

    [SerializeField] private Transform AttackController;
    [SerializeField] private float AttackRange;
    [SerializeField] private int AttackDamage;
    private Animator animator;


    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Update() {
    #if ENABLE_LEGACY_INPUT_MANAGER
    if (cooldown.IsCoolingDown) return;
        if (Vector2.Distance(AttackController.position, GameObject.FindGameObjectWithTag("Player").transform.position) < AttackRange)
        {
            animator.SetBool("Attack", true);
            Hit();
            cooldown.StartCooldown();
        }
        else
        {
            animator.SetBool("Attack", false);
        }
    #endif

        if (GameObject.FindGameObjectWithTag("Player").transform.position.x > transform.position.x)
        {
            AttackController.position = new Vector2(transform.position.x + 1, transform.position.y);
        }
        else
        {
            AttackController.position = new Vector2(transform.position.x - 1, transform.position.y);
        }

    }

    private void Hit() 
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Collider2D[] objects = Physics2D.OverlapCircleAll(AttackController.position, AttackRange);

        foreach (Collider2D a_collider in objects)
        {
            if (a_collider.CompareTag("Player"))
            {
                Debug.Log("Hit, player!");

                a_collider.GetComponent<CharacterLive>().TakeDamage(AttackDamage);
            }
        }
    } 

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(AttackController.position, AttackRange);
    }
#endif
}

