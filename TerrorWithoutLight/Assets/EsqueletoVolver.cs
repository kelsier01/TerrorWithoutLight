using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsqueletoVolver : StateMachineBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    private Esquele esqueleto;
    private Vector3 posicionInicial;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        esqueleto = animator.gameObject.GetComponent<Esquele>();
        posicionInicial = esqueleto.puntoInicial;
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        esqueleto.Girar(esqueleto.puntoInicial);
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, posicionInicial, velocidadMovimiento * Time.deltaTime);
        if (animator.transform.position == posicionInicial)
        {
            animator.SetTrigger("llegue");
        }
    }

   
}
