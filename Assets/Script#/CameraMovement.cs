using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] private Transform Target;
    [SerializeField] private float SmoothTime;
    private Vector3 Velocity = Vector3.zero;
    public void Update()
    {
        Vector3 targetPosition = new Vector3(Target.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref Velocity, SmoothTime);
    }
}
