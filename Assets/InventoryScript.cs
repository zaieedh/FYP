using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    public int NumberOfSlots;
    public Transform SlotsParent;
    public GameObject SlotPrefab;
    public GameObject InventoryItemPrefab;
    private List<GameObject> Slots;

    public void Start()
    {
        Slots = new List<GameObject>();
        for(int i = 0; i < NumberOfSlots; i++)
        {
            var slotInstance = Instantiate(SlotPrefab, SlotsParent);
            Slots.Add(slotInstance);
        }
    }

    public bool AddToInventory(Purchasable purchasable)
    {
        if (Slots.Count > 0)
        {
            GameObject emptySlot = null;
            
            for (int i = 0; i < NumberOfSlots; i++)
            {
                if(Slots[i].transform.childCount == 0)
                {
                    emptySlot = Slots[i];
                    break;
                }
            }
            
            if (emptySlot == null)
                return false;

            var inventoryItem = Instantiate(InventoryItemPrefab, emptySlot.transform);
            inventoryItem.GetComponent<InventoryItem>().itemPicture = purchasable.InventoryImage;
            inventoryItem.GetComponent<InventoryItem>().Purchasable = purchasable;
            inventoryItem.GetComponent<Button>().onClick.AddListener(() => inventoryItem.GetComponent<InventoryItem>().OnClick());
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool RemoveFromInventory(Purchasable purchasable)
    {
        if (Slots.Count > 0)
        {

            for (int i = 0; i < NumberOfSlots; i++)
            {
                if (Slots[i].transform.GetComponentInChildren<InventoryItem>()?.Purchasable == purchasable)
                {
                    Destroy(Slots[i].transform.GetComponentInChildren<InventoryItem>().gameObject);
                    break;
                }
            }
            
            return true;
        }
        else
        {
            return false;
        }
    }
}
