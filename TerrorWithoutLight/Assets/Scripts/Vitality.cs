using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Vitality : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private float vidaMaxima;
    [SerializeField] private GameObject muerte;

    public class OnTakeDamageEventArgs : EventArgs
    {
        public float CantidadVida;
    }

    private void Start()
    {
        vida = vidaMaxima;
    }
    public void recibir_daño(float daño)
    {
        vida -= daño;
        if (vida <= 0)
        {
            Destroy(gameObject);
            Instantiate(muerte, transform.position, transform.rotation);
        }
    }

    public void CurarVida(float cura)
    {

        if (vida + cura <= vidaMaxima)
        {
            vida += cura;
        }
        else
        {
            vida = vidaMaxima;
        }

    }

}
