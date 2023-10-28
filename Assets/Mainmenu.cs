using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Mainmenu : MonoBehaviour
{
    public void Nivel1()
    {
        ChangeLevel.NivelCarga("Pista_Gran_Premio");

    }
    public void Nivel2()
    {
        SceneManager.LoadScene("Level2");

    }
    public void Nivel3()
    {
        SceneManager.LoadScene("Level3");

    }
    public void Nivel4()
    {
        SceneManager.LoadScene("Level4");

    }


    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }
}