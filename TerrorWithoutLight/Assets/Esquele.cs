using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esquele : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public Transform jugador;
    [SerializeField] public float distancia;
    public Vector3 puntoInicial;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        puntoInicial = transform.position;
    }

    private void Update()
    {
        distancia = Vector2.Distance(transform.position, jugador.position);
        animator.SetFloat("distancia", distancia);
    }

    public void Girar(Vector3 objetivo)
    {
        if (objetivo.x > transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }
}
