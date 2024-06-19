using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveHud : MonoBehaviour
{
    // Desactiva una vida en base al indice que se le pase
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.LoseHP();
            }
            else
            {
                Debug.LogError("GameManager instance is null");
            }
        }
    }
}
