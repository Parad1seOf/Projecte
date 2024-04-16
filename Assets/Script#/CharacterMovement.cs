using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float velocidad;
    public float fuerzaSalto;
    public LayerMask capaSuelo;
    
    private Rigidbody2D rigidbody;
    private BoxCollider2D boxCollider2D;
    private bool mirandoDerecha = true;


    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        Salto();
    }

    void Movimiento () 
    {
        float inputMovimiento = Input.GetAxis("Horizontal");
        rigidbody.velocity = new Vector2 (inputMovimiento * velocidad, rigidbody.velocity.y);

        Rotacion(inputMovimiento);
    }

    void Rotacion (float inputMovimiento)
    {
        if ((mirandoDerecha == true && inputMovimiento < 0) || (mirandoDerecha == false && inputMovimiento > 0))
        {
            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }


    bool TocandoSuelo ()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center, new Vector2 (boxCollider2D.bounds.size.x, boxCollider2D.bounds.size.y), 0f, Vector2.down, 0.2f, capaSuelo);
        return raycastHit.collider != null; 
    }
    void Salto()
    {
        if (Input.GetKeyDown(KeyCode.W) && TocandoSuelo())
        {
            rigidbody.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }
}
