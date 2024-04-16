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
        Vector3 TargetPosition = new Vector3(Target.position.x, Target.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, TargetPosition, ref Velocity, SmoothTime);
    }
}
