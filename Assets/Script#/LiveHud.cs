using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveHud : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.PerderVida();
            }
            else
            {
                Debug.LogError("GameManager instance is null");
            }
        }
    }
}
