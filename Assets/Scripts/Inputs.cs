using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum ControlMode {Keyboard = 1, Touch =2 };
public class InputSystem : MonoBehaviour
{
        //De ser necesario añadir un flout para el input de freno igual que los otros
    public ControlMode control;
    public float Accel;
    public float Steer;
    public float Brake;
    public GameObject UI;
    public void AccelInput(float input) { Accel = input; }
    public void SteerInput(float input) { Accel = input; }

    public void BrakeInput(float input) { Brake = input; }
    Driver Player;

     void Start()
    {
        Player = GetComponent<Driver>();
    }

    void Update()
    {
        if (control == ControlMode.Keyboard)
        {
            Accel = Input.GetAxis("Vertical");
            Steer = Input.GetAxis("Horizontal");
            UI.SetActive(false);
        } else
        {
            UI.SetActive(true);
        }
    }
 
}  
