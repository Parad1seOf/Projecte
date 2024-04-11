using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {
    private Rigidbody2D rb2D;

[Header("Movement")]

    private float HorizontalMovement = 0f;
    [SerializeField] private float SpeedMovement;
    [Range(0, 0.2f)][SerializeField] private float SmoothMovement;
    private Vector3 Velocity = Vector3.zero;
    private bool FacingRight = true;

[Header("Jump")]

    [SerializeField] private float JumpForce;
    [SerializeField] private LayerMask GroundCheck;
    [SerializeField] private Transform GroundSensor;
    [SerializeField] private Vector3 ColiderDimension;
    [SerializeField] private bool Grounded;
    private bool Jump;

[Header("Animation")]

    private Animator animator;

    public void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void Update () {
        HorizontalMovement = Input.GetAxisRaw("Horizontal") * SpeedMovement;

        if (Input.GetButtonDown("Jump")) {
            Jump = true;
        }
    }

    public void FixedUpdate () {
        Grounded = Physics2D.OverlapBox(GroundSensor.position, ColiderDimension, 0f, GroundCheck);

        MoveCharacter(HorizontalMovement * Time.fixedDeltaTime, Jump);

        Jump = false;
    }

    public void MoveCharacter (float HorizontalMovement, bool Jump) {
        Vector3 TargetVelocity = new Vector2(HorizontalMovement * 10f, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, TargetVelocity, ref Velocity, SmoothMovement);

        if (HorizontalMovement > 0 && !FacingRight) {
            Flip();
        } else if (HorizontalMovement < 0 && FacingRight) {
            Flip();
        }

        if (Grounded && Jump) {
            Grounded = false;
            rb2D.AddForce(new Vector2(0f, JumpForce));
        }
    }

    public void Flip () {
        FacingRight = !FacingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    public void OnDrawGizmos () {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(GroundSensor.position, ColiderDimension);
    }
}
