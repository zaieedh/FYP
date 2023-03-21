using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    /// <summary>
    /// Instance of weapon manager
    /// </summary>
    public static WeaponManager Instance { get; private set; }
    /// <summary>
    /// Current weapon that player is using
    /// </summary>
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
    /// <summary>
    /// Checking if player is currently attacking
    /// </summary>
    private bool _attacking;

    void FixedUpdate()
    {
        //Attack with weapon if player clicks Left mouse button
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
    /// <summary>
    /// Changing weapon, putting current weapon in inventory and instantiating new weapon to player hand
    /// </summary>
    /// <param name="weapon">Weapon to change on</param>
    public void ChangeWeapon(GameObject weapon)
    {
        /*if (CurrentWeapon != null)
        {
            CurrentWeapon.gameObject.SetActive(false);
        }*/

        //PUT IN INVENTORY THEN REMOVE
        if (weapon.GetComponent<Weapon>().IsMelee)
        {
            WeaponRelatedUI.Instance.Hide();
            AimController.Instance.aimMode = AimModes.Close;
        }
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
