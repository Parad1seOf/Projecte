using UnityEngine;

[System.Serializable]
public class Cooldown 
{
    [SerializeField] private float colldownTime;
    private float _currentTime;

    public bool IsCoolingDown => Time.time < _currentTime;
    public void StartCooldown() => _currentTime = Time.time + colldownTime;    
}
