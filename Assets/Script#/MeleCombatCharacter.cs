using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleCombatCharacter : MonoBehaviour
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

    private void Update()
    {
        #if ENABLE_LEGACY_INPUT_MANAGER
        if (cooldown.IsCoolingDown) return;
        if (Input.GetButtonDown("Attack"))
        {
            Hit();
            Debug.Log("Attack");
            animator.SetTrigger("attack");

            cooldown.StartCooldown();
        }
        #endif
    }

    private void Hit() 
    {
        if (cooldown.IsCoolingDown) return;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Collider2D[] objects = Physics2D.OverlapCircleAll(AttackController.position, AttackRange);

        foreach (Collider2D a_collider in objects)
        {
            if (a_collider.CompareTag("Enemy"))
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
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackController.position, AttackRange);
    }
#endif
}
