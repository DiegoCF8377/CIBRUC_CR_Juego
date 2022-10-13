using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceCarAI : MonoBehaviour
{
    [Header("AI Car Settings")]
    public GameObject[] carModel;
    public Transform[] trackCourse = new Transform[34];
    public float minMoveSpeed = 5.0f;
    public float maxMoveSpeed = 10.0f;
    public float moveSpeed = 1f;
   
    private int trackPoint = 0;
    private Vector3 startPosition;
    private Rigidbody raceCar;      

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("TrackPoint"))
        {

            moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
            trackPoint++;
            if(trackPoint > trackCourse.Length - 1)
                trackPoint = 0;
        }
        if(other.CompareTag("OrganicTrash"))
        {
            //Debug.Log("Correct collision with OrganicTrash fuel recovered");
            other.gameObject.SetActive(false);
        }
        else if(other.CompareTag("NonOrganicTrash"))
        {
            //Debug.Log("Incorrect collision with NonOrganicTrash fuel lost");
            other.gameObject.SetActive(false);
        }
        else if(other.CompareTag("ElectronicTrash"))
        {
            //Debug.Log("Incorrect collision with ElectronicTrash fuel lost");
            other.gameObject.SetActive(false);
        }
    }

    public void moveCarThroughCourse()
    {
        if(GameManager.gameManagerInstance.startRace)
        {
            var step = moveSpeed * Time.deltaTime;
            transform.LookAt(trackCourse[trackPoint]);
            transform.position = Vector3.MoveTowards(transform.position, trackCourse[trackPoint].position, step);
        }
   
    }

    // Start is called before the first frame update
    private void Start()
    {
        carModel[Random.Range(0,6)].SetActive(true);
        raceCar = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //raceCar.velocity = transform.forward * moveSpeed;
    }
    private void Update()
    {
        moveCarThroughCourse();
    }
}
