using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManagerInstance;
    [HideInInspector]
    public bool startRace = false;

    //Head Up Display & User Inferface
    public GameObject gameOverMenu;
    public Text scoreTxt;
    public Slider fuelSlider;

    private void Awake()
    {
        gameManagerInstance = this;
    }
}
