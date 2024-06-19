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

    [SerializeField] private AudioClip EnemySoundAttack;

    // Inizializamos el componente
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Ataque con input de ataque y sonido
#if ENABLE_LEGACY_INPUT_MANAGER
        if (cooldown.IsCoolingDown) return;

        Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        
        if (Vector2.Distance(AttackController.position, playerTransform.position) < AttackRange)
        {
            animator.SetBool("Attack", true);
            Hit();
            SoundController.Instance.EjecutarSonido(EnemySoundAttack);
            cooldown.StartCooldown();
        }
        else
        {
            animator.SetBool("Attack", false);
        }
        // Cambio de direccion del ataque
        if (playerTransform.position.x > transform.position.x)
        {
            AttackController.position = new Vector2(transform.position.x + 1, transform.position.y);
        }
        else
        {
            AttackController.position = new Vector2(transform.position.x - 1, transform.position.y);
        }
#endif
    }

    // Funcion para que el jugador reciba daño
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

                if (GameManager.Instance != null)
                {
                    GameManager.Instance.LoseHP();
                }
                else
                {
                    Debug.LogError("GameManager instance is null");
                }
            }
        }
    }
    // Dibujar el rango de ataque
#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(AttackController.position, AttackRange);
    }
#endif
}
