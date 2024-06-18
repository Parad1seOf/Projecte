using UnityEngine;

public class DeathZoneRespawn : MonoBehaviour
{
    [SerializeField] private Vector2 RespawnPoint;

    public void Start () {
        RespawnPoint = transform.position;
    }

    public void OnTriggerEnter2D (Collider2D collisions) {
        if (collisions.CompareTag("DeathZone")) {
            Fall();
        }
    }

    public void Fall () {
        Respawn();
    }

    public void Respawn () {
        transform.position = RespawnPoint;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().angularVelocity = 0;
        
    }
}
