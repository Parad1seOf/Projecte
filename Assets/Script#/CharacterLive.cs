// using System.Collections;
// using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class CharacterLive : MonoBehaviour
{
    [SerializeField] private GM_Health HealthManager;

    private void Start()
    {
        //HealthManager = new GM_Health();
        Debug.Log("Initial Health: " + HealthManager.GetHealth());
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Taking damage: " + damage);
        HealthManager.TakeDamage(damage);
        Debug.Log("Current Health: " + HealthManager.GetHealth());

        if (HealthManager.GetHealth() <= 0)
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        Debug.Log("Dead");
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
