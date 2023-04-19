using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Controller of camera, mouse rotation
public class PlayerCam : MonoBehaviour
{
    /// <summary>
    /// Minimap camera
    /// </summary>
    public GameObject MinimapCam;
    /// <summary>
    /// Minimap rotation of camera on Y axis
    /// </summary>
    private float MinimapCamYRotation;
    /// <summary>
    /// Sensitivity on X axis of camera on close distance
    /// </summary>
    public float sensX;
	/// <summary>
	/// Sensitivity on X axis of camera on far distance
	/// </summary>
	public float sensXFar;
	/// <summary>
	/// Sensitivity on Y axis of camera on close distance
	/// </summary>
	public float sensY;
	/// <summary>
	/// Sensitivity on Y axis of camera on far distance
	/// </summary>
	public float sensYFar;
    /// <summary>
    /// Orientation of camera
    /// </summary>
    public Transform orientation;
    /// <summary>
    /// Rotation of camera on X axis
    /// </summary>
    float xRotation;
    /// <summary>
    /// Rotation of camera on Y axis
    /// </summary>
    float yRotation;
    /// <summary>
    /// Instance of players camera
    /// </summary>
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

        MinimapCamYRotation = MinimapCam.transform.rotation.y;
    }


    private void Update()
    {
        //Changing roration of players cam based on mouse inputs and its sensitivity based on aim mode
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
            MinimapCamYRotation += mouseX;
            xRotation -= mouseY;
            
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
            MinimapCam.transform.rotation = Quaternion.Euler(90, MinimapCamYRotation, 0);
		}
    }
}
