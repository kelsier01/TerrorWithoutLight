using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perseguirr : StateMachineBehaviour
{
    private Transform jugador;
    private Esquele esqueleto;
    [SerializeField] private float tiempoBase;
    private float tiempoFalta;
    [SerializeField] private float velocidad;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        esqueleto = animator.gameObject.GetComponent<Esquele>();
        tiempoFalta = tiempoBase;
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        esqueleto.Girar(jugador.position);
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, jugador.position, velocidad * Time.deltaTime);
        if (tiempoFalta <= 0)
        {
            animator.SetTrigger("regresar");
        }
        tiempoFalta -= Time.deltaTime;
    }
}
