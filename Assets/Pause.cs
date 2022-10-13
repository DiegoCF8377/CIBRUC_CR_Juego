using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField]private GameObject Botonpausa;
    [SerializeField] private GameObject Mainmenu;

    public void Pausa() {
        Mainmenu.SetActive(true);
        Botonpausa.SetActive(false);
        Time.timeScale = 0f;
    }

    public void Continuar(){
        Time.timeScale = 1f;
        Botonpausa.SetActive(true);
        Mainmenu.SetActive(false);
    }

    public void Salir()
    {
        SceneManager.LoadScene("Menu principal");
    }
}
