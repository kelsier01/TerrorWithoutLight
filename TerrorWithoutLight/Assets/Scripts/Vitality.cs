using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Vitality : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private float vidaMaxima;
    [SerializeField] private GameObject muerte;


    // Evento con traspaso de argumentos
    public event EventHandler<OnDamageEventArgs> OnDamage;
    // Para enviar informaci�n creamos una clase que define la informaci�n
    public class OnDamageEventArgs : EventArgs
    {
        public float CantidadVida;
    }

    private void Start()
    {
        vida = vidaMaxima;
    }
    public void recibir_da�o(float da�o)
    {
        vida -= da�o;
        if (vida <= 0)
        {
            Destroy(gameObject);
            Instantiate(muerte, transform.position, transform.rotation);
        }
        // Evento de suscripci�n. en este caso en vez de enviar un parametro vacio le enviamos el argumento 
        OnDamage?.Invoke(this, new OnDamageEventArgs { CantidadVida = vida });
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
