using UnityEngine;

[System.Serializable]
public class GM_Health
{
    [SerializeField] private int Health;

    public int GetHealth() => Health;
    public void SetHealth(int health) => Health = health;
    public void TakeDamage(int AttackDamage) => Health -= AttackDamage;
    public void Heal(int heal) => Health += heal;
    public void Die() => Health = 0;
}
