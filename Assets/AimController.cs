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
    public static AimController Instance { get; private set; }
    public float fieldOfViewClose = 50;
    public float fieldOfViewFar = 10;
    public AimModes aimMode;
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
        aimMode = AimModes.Close;
    }

    private void FixedUpdate()
    {
        if (AimController.Instance != null)
        {
            if (aimMode == AimModes.Close)
            {
                PlayerCam.Instance.gameObject.GetComponent<Camera>().fieldOfView = fieldOfViewClose;
            }
            else
            {
                PlayerCam.Instance.gameObject.GetComponent<Camera>().fieldOfView = fieldOfViewFar;
            }
        }

        if (!WeaponManager.Instance.CurrentWeapon.IsMelee)
        {
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

            if (Input.GetMouseButtonUp(1))
            {
                aiming = false;
            }
        }
    }

    public Sprite aimSpriteBlack;
    public Sprite aimSpriteRed;

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
