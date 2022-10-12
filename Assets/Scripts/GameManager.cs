using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManagerInstance;
    public bool startRace = false; 

    private void Awake()
    {
        gameManagerInstance = this;
    }
}
