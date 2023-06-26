using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Plataformas : MonoBehaviour
{
    // lista de objetos (plataformas)
    [SerializeField] private List<GameObject> plataformas;
    private PlayerMove playerMove;

    private void Start()
    {
        // buscar al jugador con la etiqueta  de player del scrip vitality
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
        // el metodo activar Se suscribe
        playerMove.OnSalto += Activar;
    }

    private void Activar(object sender, EventArgs e)
    {
        foreach (GameObject item in plataformas)
        {
            item.SetActive(!item.activeSelf);
        }
    }

}
