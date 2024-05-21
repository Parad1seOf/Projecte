// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class CharacterLive : MonoBehaviour
{
    [SerializeField] private GM_Health HealthManager;
    private Animator animator;

    private void Start()
    {
        //HealthManager = new GM_Health();
        Debug.Log("Initial Health: " + HealthManager.GetHealth());
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        animator.SetTrigger("TakeDamage");
        Debug.Log("Taking damage: " + damage);
        HealthManager.TakeDamage(damage);
        Debug.Log("Current Health: " + HealthManager.GetHealth());

        if (HealthManager.GetHealth() <= 0)
        {
            animator.SetTrigger("Die");
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Player is dead");
        HealthManager.Die();
        Destroy(gameObject);
    }
}
