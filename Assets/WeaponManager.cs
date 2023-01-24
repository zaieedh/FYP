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

    private bool _attacking;

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CurrentWeapon != null && !_attacking)
            {
                CurrentWeapon.Attack();
                _attacking = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            _attacking = false;
        }
    }

    public void ChangeWeapon(GameObject weapon)
    {
        /*if (CurrentWeapon != null)
        {
            CurrentWeapon.gameObject.SetActive(false);
        }*/

        //PUT IN INVENTORY THEN REMOVE
        if (weapon.GetComponent<Weapon>().IsMelee)
            WeaponRelatedUI.Instance.Hide();
        else
        {
            WeaponRelatedUI.Instance.weaponNameText.text = weapon.GetComponent<Weapon>().Name;
            WeaponRelatedUI.Instance.ammoText.text = weapon.GetComponent<Weapon>().Ammo.ToString();
            WeaponRelatedUI.Instance.maxAmmoText.text = weapon.GetComponent<Weapon>().MaxAmmo.ToString();
            WeaponRelatedUI.Instance.Show();
        }
        
        Purchasable copy = Instantiate(CurrentWeapon.gameObject.GetComponent<Purchasable>());
        FindObjectOfType<InventoryScript>().AddToInventory(copy);
        FindObjectOfType<InventoryScript>().RemoveFromInventory(weapon.gameObject.GetComponent<Purchasable>());
        Destroy(CurrentWeapon.gameObject);
        var instantiatedWeapon = Instantiate(weapon, transform);
        instantiatedWeapon.SetActive(true);
        CurrentWeapon = instantiatedWeapon.GetComponent<Weapon>();
    }
}
