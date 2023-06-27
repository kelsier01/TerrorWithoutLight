using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPause;
    [SerializeField] private GameObject MenuPause;
    public void Pausa(){
        Time.timeScale = 0f;
        botonPause.SetActive(false);
        MenuPause.SetActive(true);
    }
    public void Reanudar(){
        Time.timeScale = 1f;
        MenuPause.SetActive(false);
        botonPause.SetActive(true);
    }
    public void Reiniciar(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Salir(){
        Time.timeScale = 1f;
        MenuPause.SetActive(false);
        botonPause.SetActive(true);
        SceneManager.LoadScene(0);
    }

}
