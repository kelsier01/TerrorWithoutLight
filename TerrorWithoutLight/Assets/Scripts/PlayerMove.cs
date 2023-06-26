using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMove : MonoBehaviour
{
    //Player
    private Rigidbody2D rb2d;

    //Movimiento
    private float movimientoHorizontal;
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float suavizado;
    private Vector3 velocidad;

    //Giro
    [SerializeField] private bool mirarDerecha;

    //Salto
    [SerializeField] private float fuerzaSalto;
    [SerializeField] private Vector3 dimensionCaja;
    [SerializeField] private Transform infoPiso;
    [SerializeField] private LayerMask capaSuelo;
    [SerializeField] private bool estoyEnPiso;
    private bool salto;

    //Animaciones
    private Animator animator;

    //Evento sin traspaso de argumentos
    public event EventHandler OnSalto;


    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //Movimiento
        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadMovimiento;

        //Animaciones
        animator.SetFloat("MovimientoHorizontal", Mathf.Abs(movimientoHorizontal));
        animator.SetBool("EstoyEnPiso", estoyEnPiso);
        animator.SetFloat("MovimientoEnY", rb2d.velocity.y);

        //Salto
        if (Input.GetKeyDown(KeyCode.Z))
        {
            salto = true;
        }
    }

    private void FixedUpdate()
    {
        //Salto
        estoyEnPiso = Physics2D.OverlapBox(infoPiso.position, dimensionCaja, 0f, capaSuelo);

        //Movimiento
        Mover(movimientoHorizontal * Time.fixedDeltaTime);

        //Salto
        salto = false;
    }

    private void Mover(float movimientoHorizontal)
    {
        //Movimiento
        Vector3 velocidadFinal = new Vector2(movimientoHorizontal, rb2d.velocity.y);
        rb2d.velocity = Vector3.SmoothDamp(rb2d.velocity, velocidadFinal, ref velocidad, suavizado);

        //Girar
        if (movimientoHorizontal < 0 && mirarDerecha)
        {
            Girar();
        }
        else if (movimientoHorizontal > 0 && !mirarDerecha)
        {
            Girar();
        }
        Salto();
    }

    private void Salto() 
    {
        //Salto
        if (estoyEnPiso && salto)
        {
            rb2d.AddForce(new Vector2(rb2d.velocity.x, fuerzaSalto));
            estoyEnPiso = false;
            OnSalto?.Invoke(this, EventArgs.Empty);
            
        }
    }

    private void Girar()
    {
        mirarDerecha = !mirarDerecha;
        transform.eulerAngles = new Vector2(0, transform.eulerAngles.y + 180);
    }

    //Visualizar
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(infoPiso.position, dimensionCaja);
    }
}
