﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashT2 : MonoBehaviour
{
    [SerializeField] float steer = 0.1f;
    //[SerializeField] float fly = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Time.deltaTime adds frame rate independance 
        transform.Rotate(steer, 0, steer);
        //transform.Translate(0, 0 , fly);
        //steer++;
    }
}