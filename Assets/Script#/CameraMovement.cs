using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Camera")]
    private Vector3 targetPoint = Vector3.zero;
    [SerializeField] private CharacterMovement player;

    [SerializeField] private float cameraSpeed;

    void Start() {
        targetPoint = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }

    void LateUpdate() {
        targetPoint.x = player.transform.position.x;
        targetPoint.y = player.transform.position.y;

        if (targetPoint.y < 0) {
            targetPoint.y = 0;
        }

        // transform.position = targetPoint;
        transform.position = Vector3.Lerp(transform.position, targetPoint, cameraSpeed * Time.deltaTime);
    }
}
