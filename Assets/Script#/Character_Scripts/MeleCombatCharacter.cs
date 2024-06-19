using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class MeleCombatCharacter : MonoBehaviour
{

    [SerializeField] private Cooldown cooldown;

    [SerializeField] private Transform AttackController;
    [SerializeField] private float AttackRange;
    [SerializeField] private int AttackDamage;
    private Animator animator;

    [SerializeField] private AudioClip SoundAtack;

    // Inizializamos el componente
    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Ataque con input de ataque y sonido
        #if ENABLE_LEGACY_INPUT_MANAGER
        if (cooldown.IsCoolingDown) return;
        
        if (Input.GetButtonDown("Attack"))
        {
            StartCoroutine(Hit());
            Debug.Log("Attack");
            animator.SetTrigger("attack");

            cooldown.StartCooldown();

            SoundController.Instance.EjecutarSonido(SoundAtack);
        }
#endif
    }

    // Funcion para que el enemigo reciba daño
    private IEnumerator Hit() 
    {
        if (cooldown.IsCoolingDown) yield break;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Collider2D[] objects = Physics2D.OverlapCircleAll(AttackController.position, AttackRange);

        // Comprobamos si el objeto es un enemigo y le aplicamos daño
        foreach (Collider2D a_collider in objects)
        {
            if (a_collider.CompareTag("Enemy"))
            {
                Debug.Log("Hit");
                yield return new WaitForSeconds(0.5f);
                a_collider.GetComponent<LS_Enemy>().TakeDamage(AttackDamage);
            }
        }

        cooldown.StartCooldown();
    }
    // Dibujar el rango de ataque
#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackController.position, AttackRange);
    }
#endif
}
