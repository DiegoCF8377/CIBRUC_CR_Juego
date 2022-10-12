using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceCarAI : MonoBehaviour
{
    public Transform[] trackCourse;
    private Rigidbody raceCar;
    private Transform carDirection;

    // Start is called before the first frame update
    void Start()
    {
        raceCar = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        raceCar.velocity = transform.forward * 15.0f;
    }
}
