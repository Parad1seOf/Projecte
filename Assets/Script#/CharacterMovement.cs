using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Animator animator;
    public Collider2D RollColider;
    public Collider2D IdleColider;


    [SerializeField] private Cooldown cooldown;


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

    [Header("Roll")]

    [SerializeField] private float RollSpeed;
    [SerializeField] private float RollTime;
    private float InitialGravity;
    private bool CanRoll = true;
    private bool CanMove = true;

    [SerializeField] private AudioClip saltoSonido;
    [SerializeField] private AudioClip caminarSonido;


    public void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        InitialGravity = rb2D.gravityScale;
    }

    public void Update()
    {
        HorizontalMovement = Input.GetAxisRaw("Horizontal") * SpeedMovement;

        if (Input.GetButtonDown("Jump"))
        {
            Jump = true;
        }

        #if ENABLE_LEGACY_INPUT_MANAGER
        if (cooldown.IsCoolingDown) return;
        if (Input.GetButtonDown("Roll") && CanRoll)
        {
            StartCoroutine(Roll());
            cooldown.StartCooldown();
        }
#endif
    }

    public void FixedUpdate()
    {
        Grounded = Physics2D.OverlapBox(GroundSensor.position, ColiderDimension, 0f, GroundCheck);

        if (CanMove)
        {
            MoveCharacter(HorizontalMovement * Time.fixedDeltaTime, Jump);
        }

        Jump = false;
    }

    public void MoveCharacter(float horizontalMovement, bool jump)
    {
        Vector2 targetVelocity;

        if (Mathf.Approximately(horizontalMovement, 0f)) 
        {
            targetVelocity = new Vector2(0, rb2D.velocity.y);
            ControladorSonido.Instance.EjecutarSonido(caminarSonido);

        }
        else 
        {
            targetVelocity = new Vector2(horizontalMovement * 10f, rb2D.velocity.y);
            ControladorSonido.Instance.EjecutarSonido(caminarSonido);

        }

        if (Mathf.Approximately(horizontalMovement, 0f)) 
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
        }
        else 
        {
            rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, targetVelocity, ref Velocity, SmoothMovement);
        }

        animator.SetFloat("speed", Mathf.Abs(rb2D.velocity.x));
        animator.SetFloat("impulse", rb2D.velocity.y);

        if (horizontalMovement > 0 && !FacingRight) {
            Flip();
        } else if (horizontalMovement < 0 && FacingRight) {
            Flip();
        }

        if (Grounded && jump) {
            Grounded = false;
            rb2D.AddForce(new Vector2(0f, JumpForce));
            ControladorSonido.Instance.EjecutarSonido(saltoSonido);
        }
    }


    private IEnumerator Roll()
    {

        if (cooldown.IsCoolingDown) yield return null;

        if (Grounded)
        {
            CanMove = false;
            CanRoll = false;
            rb2D.gravityScale = 0;
            rb2D.velocity = new Vector2(RollSpeed * transform.localScale.x, 0);

            RollColider.enabled = true;
            IdleColider.enabled = false;
            
            animator.SetTrigger("roll");

        yield return new WaitForSeconds(RollTime);
            CanMove = true;
            CanRoll = true;
            rb2D.gravityScale = InitialGravity;

            RollColider.enabled = false;
            IdleColider.enabled = true;

        }

        cooldown.StartCooldown();
    }

    public void Flip()
    {
        FacingRight = !FacingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

#if UNITY_EDITOR
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(GroundSensor.position, ColiderDimension);
    }
#endif
}