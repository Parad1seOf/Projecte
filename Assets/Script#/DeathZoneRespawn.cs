using UnityEngine;

public class DeathZoneRespawn : MonoBehaviour
{
    [SerializeField] private Vector2 RespawnPoint;

    public void Start () {
        RespawnPoint = transform.position;
    }

    public void OnTriggerEnter2D (Collider2D collisions) {
        if (collisions.CompareTag("DeathZone")) {
            Hit();
        }
    }

    public void Hit () {
        Respawn();
    }

    public void Respawn () {
        transform.position = RespawnPoint;
        //resetea la velocidad del personaje y el angulo de rotacion
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().angularVelocity = 0;
        
    }
}
