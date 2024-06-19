using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLive : MonoBehaviour
{
    [SerializeField] private GM_Health HealthManager;
    private Animator animator;

    //Inizializamos la vida del jugador
    private void Start()
    {
        Debug.Log("Initial Health: " + HealthManager.GetHealth());
        animator = GetComponent<Animator>();
    }
    
    //Funcion para recibir daño
    public void TakeDamage(int damage)
    {
        Debug.Log("Taking damage: " + damage);
        HealthManager.TakeDamage(damage);
        Debug.Log("Current Health: " + HealthManager.GetHealth());


        //Si la vida del jugador es menor o igual a 0, se activa la animacion de muerte
        if (HealthManager.GetHealth() <= 0)
        {
            animator.SetTrigger("Die");
            StartCoroutine(Die());
        } else {
            animator.SetTrigger("TakeDamage");
        }

    }
    //Funcion de muerte del jugador
    private IEnumerator Die()
    {
        Debug.Log("Player is dead");
        HealthManager.Die();
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);
    }
}
