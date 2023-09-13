using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TrashType
    {
        OrganicTrash,
        NonOrganicTrash,
        ElectronicTrash
    }

public class ObjectSpawner : MonoBehaviour 
{
    // Declare the 3 types of trash that will be spawned
    public GameObject organicTrash; // Only trash that provides fuel
    public GameObject nonOrganicTrash;
    public GameObject electronicTrash;
    public bool isOrganicSpawned = false;
    public SpawnTracker[] trashArray = {
                                        new SpawnTracker {isSpawned = false},
                                        new SpawnTracker {isSpawned = false},
                                        new SpawnTracker {isSpawned = false}
                                       };
    

    private void setTrashActive()
    {
        // int i = 0;
        foreach (SpawnTracker trashSpawner in trashArray)
        {
            if (trashSpawner.objectReference == null)
            {
                continue;
            }
            // Debug.Log("TrashSpawner: " + trashSpawner.type + " " + " " + trashSpawner.objectReference.activeInHierarchy + " " + trashSpawner.trashTimer + " " + i);
            // i++;
            if (trashSpawner.trashTimer > 0 && !trashSpawner.objectReference.activeSelf) 
            {
                trashSpawner.trashTimer -= Time.deltaTime;
                if (isOrganicSpawned && trashSpawner.type == TrashType.OrganicTrash)
                {
                    isOrganicSpawned = false;
                }
                continue;
            }
            if (!trashSpawner.objectReference.activeSelf)
            {
                trashSpawner.isSpawned = true;
                if (!isOrganicSpawned)
                {
                    isOrganicSpawned = true;
                    trashSpawner.type = TrashType.OrganicTrash;
                } else 
                {
                    trashSpawner.type = Random.Range(0, 2) == 0 ? TrashType.NonOrganicTrash : TrashType.ElectronicTrash;
                }
                trashSpawner.objectReference.GetComponent<RandomModelSelector>().selectRandomModel(trashSpawner.type.ToString());
                trashSpawner.trashTimer = 3.0f;
                switch (trashSpawner.type)
                {
                    case TrashType.OrganicTrash:   
                        trashSpawner.objectReference.tag = "OrganicTrash";
                        break;
                    case TrashType.NonOrganicTrash:
                        trashSpawner.objectReference.tag = "NonOrganicTrash";
                        break;
                    case TrashType.ElectronicTrash:
                        trashSpawner.objectReference.tag = "ElectronicTrash";
                        break;
                }
                trashSpawner.objectReference.SetActive(true);
            }
        }
    }

    private void Update()
    {
        setTrashActive();
    }

    private void Start()
    {
        trashArray[0].objectReference = organicTrash;
        organicTrash.GetComponent<RandomModelSelector>().selectRandomModel("OrganicTrash");
        trashArray[1].objectReference = nonOrganicTrash;
        nonOrganicTrash.GetComponent<RandomModelSelector>().selectRandomModel("NonOrganicTrash");
        trashArray[2].objectReference = electronicTrash;
        electronicTrash.GetComponent<RandomModelSelector>().selectRandomModel("ElectronicTrash");
    }

}

public class SpawnTracker
{
    public bool isSpawned { get; set; }
    public TrashType type { get; set; }
    public GameObject? objectReference { get; set; }
    public float trashTimer = 0;
    
}

