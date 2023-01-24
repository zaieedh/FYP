using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponRelatedUI : MonoBehaviour
{
    public static WeaponRelatedUI Instance { get; private set; }
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

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}
