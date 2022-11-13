using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform cameraPoint;

    void FixedUpdate()
    {
        transform.position = cameraPoint.position;
    }
}
