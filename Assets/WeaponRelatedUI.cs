using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponRelatedUI : MonoBehaviour
{
    /// <summary>
    /// Instance of UI related with weapon
    /// </summary>
    public static WeaponRelatedUI Instance { get; private set; }
    /// <summary>
    /// UI objects used to display info about weapon on GUI
    /// </summary>
    public TextMeshProUGUI ammoText, maxAmmoText, weaponNameText;

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

        Hide();
    }
    /// <summary>
    /// Hiding Weapon related UI
    /// </summary>
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    /// <summary>
    /// Showing weapon related UI
    /// </summary>
    public void Show()
    {
        gameObject.SetActive(true);
    }
}
