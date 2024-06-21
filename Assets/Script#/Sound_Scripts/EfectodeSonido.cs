using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EfectodeSonido : MonoBehaviour
{
    [SerializeField] private AudioClip collect1;

    // Reproducir un sonido al colisionar con el jugador
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SoundController.Instance.EjecutarSonido(collect1);
        }
    }
}