using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public enum AimModes
{
    Far,
    Close
}
public class AimController : MonoBehaviour
{
    /// <summary>
    /// Static instance of AimController (to access it from other classes and keep only one instance of it)
    /// </summary>
    public static AimController Instance { get; private set; }
    /// <summary>
    /// Distance for field of view on Close Aim
    /// </summary>
    public float fieldOfViewClose = 50;
    /// <summary>
    /// Distance for field of view on Far Aim
    /// </summary>
    public float fieldOfViewFar = 10;
    /// <summary>
    /// AimModes enumerator, to switch between aim modes
    /// </summary>
    public AimModes aimMode;
    /// <summary>
    /// Check if player currently aiming
    /// </summary>
    private bool aiming;
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

    private void Start()
    {
        //Setting up aim mode to Close at the beggining of the game
        aimMode = AimModes.Close;
    }

    private void FixedUpdate()
    {
        //Checking if instance of PlayerCam exists
        if (PlayerCam.Instance != null)
        {
			//Checking if instance of AimController exists
			if (Instance != null)
            {
                //Checking if aimmode is close, if its close then setting up field of view of player camera to close, otherwise setting it to far
                if (aimMode == AimModes.Close)
                {
                    PlayerCam.Instance.gameObject.GetComponent<Camera>().fieldOfView = fieldOfViewClose;
                }
                else
                {
                    PlayerCam.Instance.gameObject.GetComponent<Camera>().fieldOfView = fieldOfViewFar;
                }
            }
            //Checking if current weapon type of player is not melee
            if (!WeaponManager.Instance.CurrentWeapon.IsMelee)
            {
                //If player clicks right mouse button and not currently aiming, he will change aiming mode accordingly, if its currently far it will be changed to close, if its close it will be changed to far
                if (Input.GetMouseButtonDown(1) && !aiming)
                {
                    aiming = true;
                    if (aimMode == AimModes.Close)
                    {
                        aimMode = AimModes.Far;
                    }
                    else
                    {
                        aimMode = AimModes.Close;
                    }
                }

                //If player releases right mouse button, aiming property is set to false
                if (Input.GetMouseButtonUp(1))
                {
                    aiming = false;
                }
            }
        }
    }

    /// <summary>
    /// Sprite of black aim
    /// </summary>
    public Sprite aimSpriteBlack;
    /// <summary>
    /// Sprite of red aim
    /// </summary>
    public Sprite aimSpriteRed;

    /// <summary>
    /// Changing aim sprite accordingly to what's passed as an argument to function, if its ture, changing to black, if false changing to red
    /// </summary>
    /// <param name="isBlack">Change to black sprite?</param>
    public void ChangeAimSprite(bool isBlack)
    {
        if (isBlack)
        {
            GetComponentInChildren<Image>().sprite = aimSpriteBlack;
        }
        else
        {
            GetComponentInChildren<Image>().sprite = aimSpriteRed;
        }
    }

}
