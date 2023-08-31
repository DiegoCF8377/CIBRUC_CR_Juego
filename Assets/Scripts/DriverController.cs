using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverController : MonoBehaviour
{
    //Car stats
    public float steerSpeed = 0.5f;
    public float moveSpeed = 25;
    public float driftAngleSpeed = 300f;
    public float driftSpeed = 10f;
    public float maxFuel = 100.0f;
    public float fuelLostPerFrame = 0.01f;
    public float fuelRecoveredOnRightPickUp = 34.0f;
    public float fuelLostOnWrongPickUp = 10.0f;

    //Type of trash that has to be picked-up in order to gain or lose fuel. 
    [SerializeField] 
    private bool organicTrashEngine, nonOrganicTrashEngine, electronicTrashEngine;
    private Rigidbody raceCar;
    private AudioSource carAudioSource;
    private bool engineSFX = false;
    private int score;
    //Head Up Display & User Inferface
    private bool adelante, atras, rotDerecha, rotIZquierda, derrape;

    private void OnTriggerEnter(Collider other)
    {
        
        if(organicTrashEngine)
        {
            if(other.CompareTag("OrganicTrash"))
            {
                Debug.Log("Correct collision with OrganicTrash fuel recovered");
                other.gameObject.SetActive(false);
                GameManager.gameManagerInstance.fuelSlider.value += fuelRecoveredOnRightPickUp;
                score += 10;
            }
            else if(other.CompareTag("NonOrganicTrash"))
            {
                Debug.Log("Incorrect collision with NonOrganicTrash fuel lost");
                other.gameObject.SetActive(false);
                // GameManager.gameManagerInstance.fuelSlider.value -= fuelLostOnWrongPickUp;
            }
            else if(other.CompareTag("ElectronicTrash"))
            {
                Debug.Log("Incorrect collision with ElectronicTrash fuel lost");
                other.gameObject.SetActive(false);
                // GameManager.gameManagerInstance.fuelSlider.value -= fuelLostOnWrongPickUp;
            }
        }
        else if(nonOrganicTrashEngine)
        {
            if(other.CompareTag("OrganicTrash"))
            {
                Debug.Log("Incorrect collision with OrganicTrash fuel lost");
                other.gameObject.SetActive(false);
                // GameManager.gameManagerInstance.fuelSlider.value -= fuelLostOnWrongPickUp;
            }
            else if(other.CompareTag("NonOrganicTrash"))
            {
                Debug.Log("Correct collision with NonOrganicTrash fuel recovered");
                other.gameObject.SetActive(false);
                GameManager.gameManagerInstance.fuelSlider.value += fuelRecoveredOnRightPickUp;
                score += 10;
            }
            else if(other.CompareTag("ElectronicTrash"))
            {
                Debug.Log("Incorrect collision with ElectronicTrash fuel lost");
                other.gameObject.SetActive(false);
                // GameManager.gameManagerInstance.fuelSlider.value -= fuelLostOnWrongPickUp;
            }
        }
        else if(electronicTrashEngine)
        {
            if(other.CompareTag("OrganicTrash"))
            {
                Debug.Log("Incorrect collision with OrganicTrash fuel lost");
                other.gameObject.SetActive(false);
                // GameManager.gameManagerInstance.fuelSlider.value -= fuelLostOnWrongPickUp;
            }
            else if(other.CompareTag("NonOrganicTrash"))
            {
                Debug.Log("Incorrect collision with NonOrganicTrash fuel lost");
                other.gameObject.SetActive(false);
                // GameManager.gameManagerInstance.fuelSlider.value -= fuelLostOnWrongPickUp;
            }
            else if(other.CompareTag("ElectronicTrash"))
            {
                Debug.Log("Correct collision with ElectronicTrash fuel recovered");
                other.gameObject.SetActive(false);
                GameManager.gameManagerInstance.fuelSlider.value += fuelRecoveredOnRightPickUp;
                score += 10;
            }
        }
    }

    public void HaciaAdelante()
    {
        adelante = true;
    }
    public void HaciaAtras()
    {
        atras = true;
    }

    public void RotacionDerecha()
    {
        rotDerecha = true;
    }

    public void RotacionIzquierda()
    {
        rotIZquierda = true;
    }

    public void Derrape()
    {
        derrape = true;
    }

    public void SinFuncion()
    {
        adelante = false;
        atras = false;
        rotDerecha = false;
        rotIZquierda = false;
        //SFX control
        engineSFX = false;
        derrape = false;
        carAudioSource.Stop();
    }

    public void GameOver() {
        GameManager.gameManagerInstance.gameOverMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ComputerController()
    {
        if(Input.GetAxis("Vertical") != 0)
        {
            //Time.deltaTime adds frame rate independance 
            float steerAmount;
            float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
            float driftAmount;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                steerAmount = Input.GetAxis("Horizontal") * driftAngleSpeed * Time.deltaTime;
                driftAmount = Input.GetAxis("Horizontal") * driftSpeed *-1* Time.deltaTime;
            }
            else
            {
                steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
                driftAmount = 0f;
            }

            transform.Rotate(0, steerAmount, 0);
            transform.Translate(driftAmount, 0, moveAmount);

            // GameManager.gameManagerInstance.fuelSlider.value -= fuelLostPerFrame;

            if(!engineSFX)
            {
                this.carAudioSource.Play();
                engineSFX = true;
            }
        }
        else if(Input.GetAxis("Vertical") == 0)
        {
            SinFuncion();
        }
    }

    public void OnScreenController()
    {
        if (adelante)
        {
            float moveAmount = (1 * moveSpeed * Time.deltaTime);
            transform.Translate(0, 0, moveAmount);
            // GameManager.gameManagerInstance.fuelSlider.value -= fuelLostPerFrame;
            //Engine SFX
            if(!engineSFX)
            {
                this.carAudioSource.Play();
                engineSFX = true;
            }
        }
        else if (atras)
        {
            float moveAmount = (-1 * moveSpeed * Time.deltaTime);
            transform.Translate(0, 0, moveAmount);
        }   

        if (rotDerecha)
        {
            float steerAmount;
            float driftAmount;
            if (derrape)
            {
                steerAmount = (1 * driftAngleSpeed * Time.deltaTime);
                driftAmount = (-1 * driftSpeed * Time.deltaTime);
            }
            else
            {
                steerAmount = (1 * steerSpeed * Time.deltaTime);
                driftAmount = 0;
            }
            transform.Rotate(0, steerAmount, 0);
            transform.Translate(driftAmount, 0, 0);
        }
        else if (rotIZquierda)
        {
            float steerAmount;
            float driftAmount;
            if (derrape)
            {
                steerAmount = (-1 * driftAngleSpeed * Time.deltaTime);
                driftAmount = (driftSpeed * Time.deltaTime);
            }
            else
            {
                steerAmount = (-1 * steerSpeed * Time.deltaTime);
                driftAmount = 0;
            }
            transform.Rotate(0, steerAmount, 0);
            transform.Translate(driftAmount, 0, 0);
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        /*
        if (GameManager.gameManagerInstance.fuelSlider.value <= 0)
        {
            GameOver();
        }
        */

        // If the nitro bar is full
        if (GameManager.gameManagerInstance.fuelSlider.value == 100)
        {
            moveSpeed = 50;
            GameManager.gameManagerInstance.fuelSlider.value = 0;
        }

        // If the speed is greater than 25
        if (moveSpeed > 25)
        {
            moveSpeed -= 0.2f;
        }

        ComputerController();
        OnScreenController();
        GameManager.gameManagerInstance.scoreTxt.text = score.ToString();
    }

    private void Start()
    {
        raceCar = GetComponent<Rigidbody>();
        carAudioSource = GetComponent<AudioSource>();
        GameManager.gameManagerInstance.fuelSlider.maxValue = maxFuel;
        score=0;
    }
}
