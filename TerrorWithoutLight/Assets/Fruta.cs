using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Fruta : MonoBehaviour
{
    private Vitality vitality;
    [SerializeField] private GameObject fruta;
    [SerializeField] private GameObject muro;

    private void Start()
    {
        // buscar al jugador con la etiqueta  de player del scrip vitality
        vitality = GameObject.FindGameObjectWithTag("Player").GetComponent<Vitality>();
        
        // el metodo se suscribe al evento
        vitality.OnDamage += Aparecer;
    }

    // el metodo recibe los argumentos del evento OnDamage
    private void Aparecer(object sender, Vitality.OnDamageEventArgs e ) 
    {
        if (e.CantidadVida <= 100)
        {
            // se desuscribe
            vitality.OnDamage -= Aparecer;
            // Se activan y sactivan objetos
            fruta.SetActive(!fruta.activeSelf);
            muro.SetActive(!muro.activeSelf);
        }
    }

    
}
