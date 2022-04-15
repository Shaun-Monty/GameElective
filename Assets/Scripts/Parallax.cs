using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    public Vector3 offset;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        cameraTransform.position = cameraTransform.position + offset;

    }

    private void Update()
    {
        
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += deltaMovement ;
        lastCameraPosition  = cameraTransform.position ;

    }

}
