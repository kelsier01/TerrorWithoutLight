using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreaterLife : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private GameObject fruta;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Vitality>().CurarVida(vida);

            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
