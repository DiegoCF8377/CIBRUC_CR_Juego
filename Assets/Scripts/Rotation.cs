using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Rotation : MonoBehaviour
{
    public Vector3 rotate;
    private Rigidbody rigidbody;
    public RectTransform transform;
    public float velocidad;

    private void Awake()
    {   
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(rotate);
        rotate.z = rotate.z - velocidad;
    }

}