using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Continue : MonoBehaviour
{
   public Text texto;

   private void Start(){
    
    string levelToLoad = ChangeLevel.nextLevel;
    StartCoroutine(Loading(levelToLoad));

   }
   IEnumerator Loading(string level){
    yield return new WaitForSeconds(2f);
    AsyncOperation operacion = SceneManager.LoadSceneAsync(level);
    operacion.allowSceneActivation = false;

    while(!operacion.isDone){
        if(operacion.progress >= 0.9f) //si la carga de la escena se termino
        {
            texto.text = "Presiona una tecla para continuar";
            if(Input.anyKey){
                operacion.allowSceneActivation = true;
            }
        }

        yield return null;
    }
   }
}
