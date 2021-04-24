using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    //Variable setup
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;


    void FixedUpdate ()
    {

        //final camera position
        //position of player + offset in vector space
        Vector3 dPosition = target.position + offset;


        //Taking linear interpolation to smooth camera movement
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, dPosition, smoothSpeed);


        transform.position = smoothedPosition;


    }
}
