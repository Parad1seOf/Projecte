using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDeath : MonoBehaviour
{
    public Transform respawnPoint;
    public GameObject player;
    public GameObject deathScreen;
    public GameObject deathSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.transform.position = respawnPoint.transform.position;
            deathScreen.SetActive(true);
            deathSound.SetActive(true);
        }
    }
}
