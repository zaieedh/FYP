using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PurchasableType
{
    Weapon,
    Consumable,
    Other
}

public class Purchasable : MonoBehaviour
{
    public string Name;
    public int Price;
    public Texture2D InventoryImage;
    public PurchasableType Type;
    public bool Purchased;

    public void OnPurchase()
    {
        if (FindObjectOfType<InventoryScript>().AddToInventory(this))
        {
            Purchased = true;
            gameObject.SetActive(false);
        }
    }
}
