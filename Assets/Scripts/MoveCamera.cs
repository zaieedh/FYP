using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    /// <summary>
    /// Position of camera
    /// </summary>
    public Transform cameraPosition;

    // Update is called once per frame
    void Update()
    {
        //updating position of camera
        transform.position = cameraPosition.position;
    }
}
