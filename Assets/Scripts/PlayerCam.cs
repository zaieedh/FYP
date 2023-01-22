using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Controller of camera, mouse rotation
public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensXFar;
    public float sensY;
    public float sensYFar;

    public Transform orientation;

    float xRotation;
    float yRotation;

    public static PlayerCam Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if (!GameManager.isMenuOpened)
        {
            if (AimController.Instance.aimMode == AimModes.Far)
            {
                sensY = sensYFar;
                sensX = sensXFar;
            }
            
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

            yRotation += mouseX;

            xRotation -= mouseY;
            
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }
}
