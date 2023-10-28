using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class ChangeLevel
{
    public static string nextLevel;

    public static void NivelCarga(string name) {
        nextLevel = name;
        SceneManager.LoadScene("PantallaDeCarga");
    }
}
