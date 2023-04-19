using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    /// <summary>
    /// Number of slots in inventory
    /// </summary>
    public int NumberOfSlots;
    /// <summary>
    /// Parent of all slots
    /// </summary>
    public Transform SlotsParent;
    /// <summary>
    /// Prefab of slot
    /// </summary>
    public GameObject SlotPrefab;
    /// <summary>
    /// Prefab of inventory item
    /// </summary>
    public GameObject InventoryItemPrefab;
    /// <summary>
    /// List of slots
    /// </summary>
    private List<GameObject> Slots;
    /// <summary>
    /// Manager for bottom slots
    /// </summary>
    public QuickSlotsManager QuickSlotsManager;

    /// <summary>
    /// Creating empty slots on start, based on number of slots player can have
    /// </summary>
    public void Awake()
    {
        Slots = new List<GameObject>();
        for(int i = 0; i < NumberOfSlots; i++)
        {
            var slotInstance = Instantiate(SlotPrefab, SlotsParent);
            Slots.Add(slotInstance);
        }
    }
    /// <summary>
    /// Adding purchased item to inventory
    /// </summary>
    /// <param name="purchasable">Instance of purchased item</param>
    /// <returns></returns>
    public bool AddToInventory(Purchasable purchasable)
    {
        if (Slots.Count > 0)
        {
            GameObject emptySlot = null;
            
            //check whihc slot is first to be available
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

            CreateInventoryItem(purchasable, emptySlot.transform);

            //game screen quick slots.
            if (QuickSlotsManager.AssignToSlot() != null)
            {
                //find the first available free slot  then get the quick slot componenet from the current slot.
				var quickSlot = QuickSlotsManager.AssignToSlot().GetComponent<QuickSlot>();

                //the item purchased image is added to the child "item" of the slot 
				var item = CreateInventoryItem(purchasable, QuickSlotsManager.AssignToSlot().Find("Item").transform);
                purchasable.QuickSlotId = quickSlot.Id;
                quickSlot.AssignItem(item);
            }

			return true;
        }
        else
        {
            return false;
        }
    }

    private GameObject CreateInventoryItem(Purchasable purchasable, Transform parent)
    {

		var inventoryItem = Instantiate(InventoryItemPrefab, parent);
		inventoryItem.GetComponent<InventoryItem>().itemPicture = purchasable.InventoryImage;
		inventoryItem.GetComponent<InventoryItem>().Purchasable = purchasable;
		inventoryItem.GetComponent<Button>().onClick.AddListener(() => inventoryItem.GetComponent<InventoryItem>().OnClick());
        return inventoryItem;
	}
    /// <summary>
    /// Removing item from inventory
    /// </summary>
    /// <param name="purchasable">Instance of purchased item to remove</param>
    /// <returns></returns>
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

			if (purchasable.QuickSlotId != 0)
			{
                QuickSlotsManager.GetItemAtId(purchasable.QuickSlotId).GetComponent<QuickSlot>().IsEmpty = true;
				foreach (Transform tf in QuickSlotsManager.GetItemAtId(purchasable.QuickSlotId).Find("Item").transform)
				{
					Destroy(tf.gameObject);
				}
			}

			return true;
        }
        else
        {
            return false;
        }
    }
    /// <summary>
    /// Getting inventory item by its name as Purchasable from Inventory
    /// </summary>
    /// <param name="name">Name of item</param>
    /// <returns>Item as Purchasable object</returns>
    public Purchasable GetInventoryItemByName(string name)
    {
        if (Slots.Count > 0)
        {

            for (int i = 0; i < NumberOfSlots; i++)
            {
                Purchasable purchasable = Slots[i].transform.GetComponentInChildren<InventoryItem>()?.Purchasable;

				if (purchasable!=null && purchasable.Name == name)
                {
                    return purchasable;
                }
            }
        }
        return null;
    }
    /// <summary>
    /// Returning list of inventory items
    /// </summary>
    /// <returns>List of inventory items names</returns>
    public List<string> GetNamesOfInventoryItems()
    {
        List<string> currentItems = new List<string>();

		if (Slots.Count > 0)
		{

			for (int i = 0; i < NumberOfSlots; i++)
			{
				Purchasable purchasable = Slots[i].transform.GetComponentInChildren<InventoryItem>()?.Purchasable;

				if (purchasable != null)
				{
                    currentItems.Add(purchasable.Name);
				}
			}
		}
		return currentItems;
	}
}
