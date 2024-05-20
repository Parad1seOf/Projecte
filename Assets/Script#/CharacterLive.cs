using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLive : MonoBehaviour
{
    [SerializeField] private GM_Health HealthManager;

    private void Start()
    {
        HealthManager = new GM_Health();
    }

    public void TakeDamage(int damage)
    {
        HealthManager.TakeDamage(damage);

    }

    public void Die()
    {

        HealthManager.Die();
        Destroy(gameObject);
    }
}
