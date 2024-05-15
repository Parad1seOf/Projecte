using UnityEngine;

[System.Serializable]
public class GM_Health
{
[SerializeField] private int health;

    public void TakeDamage(int AttackDamage)
    {
        health -= AttackDamage;
        if (health <= 0)
        {
            Die();
        }
    }

    public int GetHealth()
    {
        return health;
    }

    protected virtual void Die()
    {
        
    }
}
