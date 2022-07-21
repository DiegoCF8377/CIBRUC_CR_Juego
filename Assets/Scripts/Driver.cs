using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Driver : MonoBehaviour
{
    //Car stats
    [SerializeField] float steerSpeed = 0.5f;
    [SerializeField] float moveSpeed = 1500;
    [SerializeField] float maxFuel = 100.0f;
    [SerializeField] float fuelLostPerFrame = 0.01f;
    [SerializeField] float fuelRecoveredOnRightPickUp = 10.0f;
    [SerializeField] float fuelLostOnWrongPickUp = 10.0f;

    //Type of trash that has to be picked-up in order to gain or lose fuel. 
    [SerializeField] bool OrganicTrashEngine;
    [SerializeField] bool NonOrganicTrashEngine;
    [SerializeField] bool ElectronicTrashEngine;

    public Slider fuelSlider;
    
    void Start()
    {
        this.fuelSlider.maxValue = maxFuel;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(OrganicTrashEngine)
        {
            if(other.CompareTag("OrganicTrash"))
            {
                Debug.Log("Correct collision with OrganicTrash fuel recovered");
                other.gameObject.SetActive(false);
                this.fuelSlider.value += fuelRecoveredOnRightPickUp;
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
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Time.deltaTime adds frame rate independance 
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        fuelSlider.value -= fuelLostPerFrame;

        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
}
