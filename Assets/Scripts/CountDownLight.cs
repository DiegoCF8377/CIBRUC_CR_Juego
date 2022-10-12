using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownLight : MonoBehaviour
{
    public float countDownTimer = 5.0f;
    private float countDownTimerLimit;
    private int lightsCounter = 0;

    public GameObject [] lights = new GameObject[4]; 
    public Cinemachine.CinemachineVirtualCamera playerCamera;

    public void countDown()
    {
        if(countDownTimer > 0.0f)
        {
            countDownTimer -= Time.deltaTime;
        }
        else if(lightsCounter == lights.Length)
        {
            GameManager.gameManagerInstance.startRace = true;
            this.gameObject.SetActive(false);
        }
        else if(countDownTimer < 0.0f)
        {
            playerCamera.Priority = 10;
            lights[lightsCounter].SetActive(true);
            lightsCounter++;
            countDownTimer = countDownTimerLimit;
        } 
    }

    // Start is called before the first frame update
    void Start()
    {
        this.countDownTimerLimit = countDownTimer;
    }

    // Update is called once per frame
    void Update()
    {
        this.countDown();
    }
}
