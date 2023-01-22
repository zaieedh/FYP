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
        /*if (CurrentWeapon != null)
        {
            CurrentWeapon.gameObject.SetActive(false);
        }*/

        //PUT IN INVENTORY THEN REMOVE
        Purchasable copy = Instantiate(CurrentWeapon.gameObject.GetComponent<Purchasable>());
        FindObjectOfType<InventoryScript>().AddToInventory(copy);
        FindObjectOfType<InventoryScript>().RemoveFromInventory(weapon.gameObject.GetComponent<Purchasable>());
        Destroy(CurrentWeapon.gameObject);
        var instantiatedWeapon = Instantiate(weapon, transform);
        instantiatedWeapon.SetActive(true);
        CurrentWeapon = instantiatedWeapon.GetComponent<Weapon>();
    }
}
