using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    //Camera position centerd within car
    [SerializeField] GameObject ThingToFollow;
    [SerializeField] float Distance;
    // Update is called once per frame
    void Update()
    {
        //-10 For z axis to see car
        transform.position = ThingToFollow.transform.position + new Vector3 (0,0,Distance);
    }
}
