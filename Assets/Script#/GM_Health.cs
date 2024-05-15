using UnityEngine;

[System.Serializable]
public class GM_Health
{
    [SerializeField] private int Health;
    // [SerializeField] private int MaxHealth;

    public int GetHealth() => Health;
    // public int GetMaxHealth() => MaxHealth;

    public void SetHealth(int health) => Health = health;
    // public void SetMaxHealth(int maxHealth) => MaxHealth = maxHealth;

    public void TakeDamage(int AttackDamage) => Health -= AttackDamage;
    public void Heal(int heal) => Health += heal;
    public void Die() => Health = 0;
    // public void FullHeal() => Health = MaxHealth;
    // public void FullHealMax() => Health = MaxHealth;
}
