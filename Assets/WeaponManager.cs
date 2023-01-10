using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager Instance { get; private set; }
    public Weapon CurrentWeapon;
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

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CurrentWeapon != null)
            {
                CurrentWeapon.Attack();
            }
        }
    }

    public void ChangeWeapon(GameObject weapon)
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        var instantiatedWeapon = Instantiate(weapon, transform);
        instantiatedWeapon.SetActive(true);
        CurrentWeapon = instantiatedWeapon.GetComponent<Weapon>();
    }
}
