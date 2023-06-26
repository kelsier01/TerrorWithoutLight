using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEsqueleto : MonoBehaviour
{
     [SerializeField] private float da�o;
    [SerializeField] private float timePerDamage;
    private float tiempoEspera;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            tiempoEspera -= Time.deltaTime;
            if (tiempoEspera <= 0)
            {
                collision.collider.GetComponent<Vitality>().recibir_da�o(da�o);
                tiempoEspera = timePerDamage;
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

        }
    }
}
