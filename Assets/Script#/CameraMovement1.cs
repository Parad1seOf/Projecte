using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] private CharacterMovement player;
    [SerializeField] private float cameraSpeed;

    private Vector3 initialOffset;

    void Start()
    {
        // Calcular el desplazamiento inicial entre la cámara y el jugador
        initialOffset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        // Calcular el punto objetivo de la cámara sumando el desplazamiento inicial al jugador
        Vector3 targetPoint = player.transform.position + initialOffset;

        // Limitar el movimiento de la cámara si el jugador está por debajo de cierta altura
        if (targetPoint.y < 0)
        {
            targetPoint.y = 0;
        }

        // Mover suavemente la cámara hacia el punto objetivo
        transform.position = Vector3.Lerp(transform.position, targetPoint, cameraSpeed * Time.deltaTime);
    }
}
