using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomModelSelector : MonoBehaviour
{
    public GameObject [] trashModels = new GameObject[3];

    public void selectRandomModel(int randomIndex)
    {
        trashModels[randomIndex].SetActive(true);
    }
    public void deactivateAllTrashModels()
    {
        trashModels[0].SetActive(false);
        trashModels[1].SetActive(false);
        trashModels[2].SetActive(false);
    }
}
