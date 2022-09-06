using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject organicTrash;
    public GameObject nonOrganicTrash;
    public GameObject electronicTrash;

    public bool spawnOrganic = false;
    public bool spawnNonOrganic = false;
    public bool spawnElectronic = false;

    public float trashTimer = 10.0f;
    private float trashTimerLimit;

    public void setTrashActive()
    {
        if(spawnOrganic && organicTrash.activeInHierarchy == false)
        {
            if(trashTimer <= 0)
            {
                organicTrash.SetActive(true);
                organicTrash.GetComponent<RandomModelSelector>().deactivateAllTrashModels();
                organicTrash.GetComponent<RandomModelSelector>().selectRandomModel(Random.Range(0,3));
                trashTimer = trashTimerLimit;
            }
            else if(trashTimer > 0)
            {
                trashTimer -= Time.deltaTime;
            }
        }
        else if(spawnNonOrganic && nonOrganicTrash.activeInHierarchy == false)
        {
            if(trashTimer <= 0)
            {
                nonOrganicTrash.SetActive(true);
                nonOrganicTrash.GetComponent<RandomModelSelector>().deactivateAllTrashModels();
                nonOrganicTrash.GetComponent<RandomModelSelector>().selectRandomModel(Random.Range(0,3));
                trashTimer = trashTimerLimit;
            }
            else if(trashTimer > 0)
            {
                trashTimer -= Time.deltaTime;
            }
        }
        else if(spawnElectronic && electronicTrash.activeInHierarchy == false)
        {
            if(trashTimer <= 0)
            {
                electronicTrash.SetActive(true);
                electronicTrash.GetComponent<RandomModelSelector>().deactivateAllTrashModels();
                electronicTrash.GetComponent<RandomModelSelector>().selectRandomModel(Random.Range(0,3));
                trashTimer = trashTimerLimit;
            }
            else if(trashTimer > 0)
            {
                trashTimer -= Time.deltaTime;
            }
        }
    }

    private void Update()
    {
        setTrashActive();  
    }

    private void Start()
    {
        trashTimerLimit = trashTimer;
    }
}
