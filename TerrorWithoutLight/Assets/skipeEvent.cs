using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skipeEvent : MonoBehaviour
{
    private Vitality vitality;
    private void Start()
    {
        // buscar al jugador con la etiqueta  de player del scrip vitality
        vitality = GameObject.FindGameObjectWithTag("Player").GetComponent<Vitality>();

        // Se suscribe al evento
        vitality.OnDamage += Destruir;
    }

    // el metodo recibe los argumentos del evento OnDamage
    private void Destruir(object sender, Vitality.OnDamageEventArgs e)
    {
        if (e.CantidadVida <= 100) 
        {
            // se desuscribe
            vitality.OnDamage -= Destruir;

            Destroy(gameObject);
        }
    }
}
