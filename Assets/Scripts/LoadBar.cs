using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Image LoadingBarFill;

    public void LoadScreen(int sceneId)
    {
        StartCoroutine(LoadingSceneAsync(sceneId));
    }

    IEnumerator LoadingSceneAsync(int sceneID)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);

        LoadingScreen.SetActive(true);

        while (!operation.isDone)
        {

            Debug.Log(operation.progress);

            // float progressValue = Mathf.Clamp01(operation.progress / 0.9f);

            // LoadingBarFill.fillAmount = progressValue;

            yield return null;
        }
    } 
}
