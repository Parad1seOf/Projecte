using UnityEngine;

[System.Serializable]
public class Cooldown
{
    [SerializeField] private float cooldownTime;
    private float _currentTime;

    public bool IsCoolingDown => Time.time < _currentTime;

    public void StartCooldown() => _currentTime = Time.time + cooldownTime;
}
