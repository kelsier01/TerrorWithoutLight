using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoPlataforma : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocidad;
    public Transform controladorSuelo;
    public float distancia;
    public bool moviendoDerecha;

    public Rigidbody2D rb;

    public Animator animator;

    private void Start(){
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate(){
       RaycastHit2D informacionSuelo = Physics2D.Raycast(controladorSuelo.position, Vector2.down, distancia);
       rb.velocity = new Vector2(velocidad, rb.velocity.y);
       animator.SetBool("camina", true);
       if(informacionSuelo == false){
            Girar();
       }
    }

    private void Girar(){
        moviendoDerecha = !moviendoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        velocidad = velocidad * -1;
    }
    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controladorSuelo.transform.position, controladorSuelo.transform.position + Vector3.down * distancia);
    }
}
