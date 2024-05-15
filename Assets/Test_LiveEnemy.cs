using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_LiveEnemy : MonoBehaviour
{
    [SerializeField] private GM_Health healthManager;

    private void Start()
    {
        healthManager = new GM_Health();
    }   
    public void TakeDamage(int damage)
    {
        healthManager.TakeDamage(damage);
    }
}
