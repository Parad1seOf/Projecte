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
        
    }

    private void Hit() 
    {
        if (cooldown.IsCoolingDown) return;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Collider2D[] objects = Physics2D.OverlapCircleAll(AttackController.position, AttackRange);

        foreach (Collider2D a_collider in objects)
        {
            if (a_collider.CompareTag("Player"))
            {
                Debug.Log("Hit");
                a_collider.GetComponent<LS_Enemy>().TakeDamage(AttackDamage);
            }
        }

        cooldown.StartCooldown();
    }
    

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(AttackController.position, AttackRange);
    }
#endif
}

