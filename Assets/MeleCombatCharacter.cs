// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class MeleCombatCharacter : MonoBehaviour
{
[SerializeField] private Transform AttackController;
[SerializeField] private float Attackrange;
[SerializeField] private float AttackDamage;

private void Update()
{
    if (Input.GetButtonDown("Attack"))
    {
        Hit();
    }
}
private void Hit() 
{
    Collider2D[] objects = Physics2D.OverlapCircleAll(AttackController.position, Attackrange);

    foreach (Collider2D a_collider in objects)
    {
        if (a_collider.CompareTag("Enemy"))
        {
            // a_collider.transform.GetComponent<Enemy>().TakeDamage(AttackDamage);
        }
    }
}

#if UNITY_EDITOR
private void OnDrawGizmosSelected()
{
Gizmos.color = Color.red;
Gizmos.DrawWireSphere(AttackController.position, Attackrange);
}
#endif
}
