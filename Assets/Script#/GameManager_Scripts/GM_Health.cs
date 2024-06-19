using UnityEngine;

[System.Serializable]
public class GM_Health
{
    [SerializeField] private int Health;

    // Inicializamos la vida del jugador
    public int GetHealth() => Health;
    // Establecemos la vida del jugador
    public void SetHealth(int health) => Health = health;
    // Recibir daño
    public void TakeDamage(int AttackDamage) => Health -= AttackDamage;
    // Curar
    public void Heal(int heal) => Health += heal;
    // Morir
    public void Die() => Health = 0;
}
