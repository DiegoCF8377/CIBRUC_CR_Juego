using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Driver : MonoBehaviour
{
    //Control Keys
    public KeyCode forward = KeyCode.W;
    //Car stats
    [SerializeField] float steerSpeed = 0.5f;
    [SerializeField] float moveSpeed = 1500;
    [SerializeField] float maxFuel = 100.0f;
    [SerializeField] float fuelLostPerFrame = 0.01f;
    [SerializeField] float fuelRecoveredOnRightPickUp = 10.0f;
    [SerializeField] float fuelLostOnWrongPickUp = 10.0f;

    //Game Over Pause
    [SerializeField] private GameObject gameOverMenu;

    private bool adelante;
    private bool atras;
    //private bool derecha;
    //private bool izquierda;
    private bool rotDerecha;
    private bool rotIZquierda;

    //Type of trash that has to be picked-up in order to gain or lose fuel. 
    [SerializeField] bool OrganicTrashEngine;
    [SerializeField] bool NonOrganicTrashEngine;
    [SerializeField] bool ElectronicTrashEngine;

    public AudioSource carAudioSource;
    private bool engineSFX = false;

    public Text scoreTxt;
    public int score;

    public Slider fuelSlider;
    


    private void OnTriggerEnter(Collider other)
    {
        if(OrganicTrashEngine)
        {
            if(other.CompareTag("OrganicTrash"))
            {
                Debug.Log("Correct collision with OrganicTrash fuel recovered");
                other.gameObject.SetActive(false);
                this.fuelSlider.value += fuelRecoveredOnRightPickUp;
                score += 10;
            }
            else if(other.CompareTag("NonOrganicTrash"))
            {
                Debug.Log("Incorrect collision with NonOrganicTrash fuel lost");
                other.gameObject.SetActive(false);
                this.fuelSlider.value -= fuelLostOnWrongPickUp;
            }
            else if(other.CompareTag("ElectronicTrash"))
            {
                Debug.Log("Incorrect collision with ElectronicTrash fuel lost");
                other.gameObject.SetActive(false);
                this.fuelSlider.value -= fuelLostOnWrongPickUp;
            }
        }
        else if(NonOrganicTrashEngine)
        {
            if(other.CompareTag("OrganicTrash"))
            {
                Debug.Log("Incorrect collision with OrganicTrash fuel lost");
                other.gameObject.SetActive(false);
                this.fuelSlider.value -= fuelRecoveredOnRightPickUp;
            }
            else if(other.CompareTag("NonOrganicTrash"))
            {
                Debug.Log("Correct collision with NonOrganicTrash fuel recovered");
                other.gameObject.SetActive(false);
                this.fuelSlider.value += fuelLostOnWrongPickUp;
                score += 10;
            }
            else if(other.CompareTag("ElectronicTrash"))
            {
                Debug.Log("Incorrect collision with ElectronicTrash fuel lost");
                other.gameObject.SetActive(false);
                this.fuelSlider.value -= fuelLostOnWrongPickUp;
            }
        }
        else if(ElectronicTrashEngine)
        {
            if(other.CompareTag("OrganicTrash"))
            {
                Debug.Log("Incorrect collision with OrganicTrash fuel lost");
                other.gameObject.SetActive(false);
                this.fuelSlider.value -= fuelRecoveredOnRightPickUp;
            }
            else if(other.CompareTag("NonOrganicTrash"))
            {
                Debug.Log("Incorrect collision with NonOrganicTrash fuel lost");
                other.gameObject.SetActive(false);
                this.fuelSlider.value -= fuelLostOnWrongPickUp;
            }
            else if(other.CompareTag("ElectronicTrash"))
            {
                Debug.Log("Correct collision with ElectronicTrash fuel recovered");
                other.gameObject.SetActive(false);
                this.fuelSlider.value += fuelLostOnWrongPickUp;
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

    public void HaciaIzquierda()
    {
        //izquierda = true;
    }
    public void HaciaDerecha()
    {
        //derecha = true;
    }

    public void RotacionDerecha()
    {
        rotDerecha = true;
    }

    public void RotacionIzquierda()
    {
        rotIZquierda = true;
    }

    public void sinFuncion()
    {
        adelante = false;
        atras = false;
        //derecha = false;
        //izquierda = false;
        rotDerecha = false;
        rotIZquierda = false;
        //SFX control
        engineSFX = false;
        this.carAudioSource.Stop();
    }

    public void gameOver() {
        gameOverMenu.SetActive(true);
        Time.timeScale = 0f;  
    }

    /*public void computerController()
    {
        //Time.deltaTime adds frame rate independance 
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }*/

    // Update is called once per frame
    private void Update()
    {
        //this.computerController();
       
        if (adelante == true)
        {
            float moveAmount = (1 * moveSpeed * Time.deltaTime);
            transform.Translate(0, moveAmount, 0);
            //Engine SFX
            if(!engineSFX)
            {
                this.carAudioSource.Play();
                engineSFX = true;
            }
        }

        if (atras == true)
        {
            float moveAmount = (-1 * moveSpeed * Time.deltaTime);
            transform.Translate(0, moveAmount, 0);
        }    

        if (rotDerecha == true)
        {
            float steerAmount =(1 * steerSpeed * Time.deltaTime);
            transform.Rotate(0, 0, -steerAmount);
        }

        if (rotIZquierda == true)
        {
            float steerAmount =(-1 * steerSpeed * Time.deltaTime);
            transform.Rotate(0, 0, -steerAmount);
        }
        
        fuelSlider.value -= fuelLostPerFrame;
        if (fuelSlider.value <= 0){
            gameOver();
        }
        scoreTxt.text = score.ToString();
    }

    private void Start()
    {
        this.carAudioSource = GetComponent<AudioSource>();
        this.fuelSlider.maxValue = maxFuel;
        score=0;
    }
}
