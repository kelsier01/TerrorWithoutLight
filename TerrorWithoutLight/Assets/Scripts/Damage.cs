using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private float daño;
    [SerializeField] private float timePerDamage;
    private float tiempoEspera;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            tiempoEspera -= Time.deltaTime;
            if (tiempoEspera <= 0)
            {
                collision.GetComponent<Vitality>().recibir_daño(daño);
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
