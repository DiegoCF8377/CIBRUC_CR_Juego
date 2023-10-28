using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class CargaNivel
{
    public static string siguienteNivel;

    public static void NivelCarga(string nombre){
        siguienteNivel = nombre;
        SceneManager.LoadScene("PantallaDeCarga");
    }
}
