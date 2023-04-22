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
	
	/// <summary>
	/// Name of purchasable item
	/// </summary>
	public string Name;
    /// <summary>
    /// Price of purchasable item
    /// </summary>
    public int Price;
    /// <summary>
    /// Info to be displayed
    /// </summary>
    public string Info;
    /// <summary>
    /// Image of purchasable item once its added to inventory
    /// </summary>
    public Texture2D InventoryImage;
    /// <summary>
    /// Type of purchasable object, either Weapon, Consumable or Other
    /// </summary>
    public PurchasableType Type;
    /// <summary>
    /// Check if item is purchased
    /// </summary>
    public bool Purchased;
    /// <summary>
    /// Id of quick slot this item is attached to
    /// </summary>
	public int QuickSlotId;
	/// <summary>
	/// Adding item to inventory on purchasing it
	/// </summary>
	public void OnPurchase()
    {
        if (FindObjectOfType<InventoryScript>().AddToInventory(this))
        {
            Purchased = true;
            gameObject.SetActive(false);
        }
        if (Name == "RussianRadio")
        {
            var playerRaycastController = FindObjectOfType<PlayerRaycastController>();
			playerRaycastController.questsManager.GetQuestByName("Second Quest").GetTaskByName("Find Radio").IsCompleted = true;
            playerRaycastController.questsGuiManager.UpdateGUI();
		}
    }
}
