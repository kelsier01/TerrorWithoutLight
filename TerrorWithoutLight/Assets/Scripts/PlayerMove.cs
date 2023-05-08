using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float movimientoHorizontal;
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float suavizado;
    [SerializeField] private Vector3 velocidad;
    [SerializeField] private bool mirarDerecha;

    [SerializeField] private float fuerzaSalto;
    [SerializeField] private Vector3 dimensionCaja;
    [SerializeField] private Transform infoPiso;
    [SerializeField] private LayerMask capaSuelo;
    [SerializeField] private bool estoyEnPiso;
    private bool salto;

    private Animator animator;


    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadMovimiento;
        animator.SetFloat("MovimientoHorizontal", Mathf.Abs(movimientoHorizontal));
        animator.SetBool("EstoyEnPiso", estoyEnPiso);
        animator.SetFloat("MovimientoEnY", rb2d.velocity.y);
        if (Input.GetButtonDown("Jump"))
        {
            salto = true;
        }
    }

    private void FixedUpdate()
    {
        estoyEnPiso = Physics2D.OverlapBox(infoPiso.position, dimensionCaja, 0f, capaSuelo);
        Mover(movimientoHorizontal * Time.fixedDeltaTime);
        salto = false;
    }

    private void Mover(float movimientoHorizontal)
    {
        Vector3 velocidadFinal = new Vector2(movimientoHorizontal, rb2d.velocity.y);
        rb2d.velocity = Vector3.SmoothDamp(rb2d.velocity, velocidadFinal, ref velocidad, suavizado);
        if (movimientoHorizontal < 0 && mirarDerecha)
        {
            Girar();
        }
        else if (movimientoHorizontal > 0 && !mirarDerecha)
        {
            Girar();
        }
        if (estoyEnPiso && salto)
        {
            rb2d.AddForce(new Vector2(0f, fuerzaSalto));
        }
    }

    private void Girar()
    {
        mirarDerecha = !mirarDerecha;
        transform.eulerAngles = new Vector2(0, transform.eulerAngles.y + 180);
        //Vector3 escala = rb2d.transform.localScale;
        //escala.x *= -1;
        //rb2d.transform.localScale = escala;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(infoPiso.position, dimensionCaja);
    }
}
