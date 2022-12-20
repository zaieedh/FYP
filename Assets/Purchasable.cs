using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purchasable : MonoBehaviour
{
    public string Name;
    public int Price;
    public Texture2D InventoryImage;

    public void OnPurchase()
    {
        FindObjectOfType<InventoryScript>().AddToInventory(this);
        Destroy(gameObject);
    }
}
