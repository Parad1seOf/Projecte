using UnityEngine;

[System.Serializable]
public class Cooldown
{
    [SerializeField] private float cooldownTime;
    private float _currentTime;

    // Propiedad que devuelve si el cooldown esta activo
    public bool IsCoolingDown => Time.time < _currentTime;

    // Inicializa el cooldown
    public void StartCooldown() => _currentTime = Time.time + cooldownTime;
}
