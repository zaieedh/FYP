using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class SaveLoadController : MonoBehaviour
{
    /// <summary>
    /// Array of purchasable items that can be saved and loaded
    /// </summary>
	public GameObject[] PurchasablePrefabs;



    // Start is called before the first frame update
    void Start()
    {
        Load();
    }
    /// <summary>
    /// Loading players position from PlayerPrefs variable 'PlayerPosition'
    /// </summary>
    public void LoadPlayersPosition()
    {
        var playerPositionRecord = PlayerPrefs.GetString("PlayerPosition", "");

		if (string.IsNullOrEmpty(playerPositionRecord))
		{
			return;
		}

		var playerPosition = playerPositionRecord.Split(";")?.Select(a => {
			float.TryParse(a, out float b);
			return b;
		}).ToList();

        FindObjectOfType<PlayerScript>().transform.position = new Vector3(playerPosition[0], playerPosition[1], playerPosition[2]);
	}
    /// <summary>
    /// Saving players position to PlayerPrefs variable 'PlayerPosition'
    /// </summary>
    public void SavePlayersPosition()
    {
        var playerPosition = FindObjectOfType<PlayerScript>().transform.position;
        PlayerPrefs.SetString("PlayerPosition", $"{playerPosition.x};{playerPosition.y};{playerPosition.z}");
    }
    /// <summary>
    /// Saving players inventory to PlayerPrefs variable 'PlayersInventory'
    /// </summary>
    public void SavePlayersInventory()
    {
		var inventory = FindObjectOfType<InventoryScript>();
		var itemsNames = string.Join(";", inventory.GetNamesOfInventoryItems());
        PlayerPrefs.SetString("PlayersInventory", itemsNames);
	}
    /// <summary>
    /// Loading players inventory from PlayerPrefs variable 'PlayersInventory'
    /// </summary>
    public void LoadPlayersInventory()
    {
        var items = PlayerPrefs.GetString("PlayersInventory", "");
        if (string.IsNullOrEmpty(items))
            return;
        
        foreach(var item in items.Split(";"))
        {
            if (PurchasablePrefabs.Any(a => a.GetComponent<Purchasable>().Name == item))
                PurchasablePrefabs.First(a => a.GetComponent<Purchasable>().Name == item).GetComponent<Purchasable>().OnPurchase();
		}
	}
    /// <summary>
    /// Saving players money to PlayerPrefs variable 'Money'
    /// </summary>
    public void SaveMoney()
    {
        PlayerPrefs.SetInt("Money", GameManager.money);
    }
    /// <summary>
    /// Saving number of ghouls killed
    /// </summary>
	public void SaveGhouls()
	{
		PlayerPrefs.SetInt("GhoulsKilled", PlayerRaycastController.ghoulsKilled);
		PlayerPrefs.Save();
	}
    /// <summary>
    /// Saving current active quest of player
    /// </summary>
    public void SaveCurrentQuest()
    {
        PlayerPrefs.SetString("CurrentQuest", FindObjectOfType<PlayerRaycastController>().questsManager.GetActiveQuestName());
    }
    /// <summary>
    /// Loading current active quest of player
    /// </summary>
	public void LoadCurrentQuest()
	{
		var questName = PlayerPrefs.GetString("CurrentQuest", "");
        if (!string.IsNullOrEmpty(questName))
        {
            FindObjectOfType<PlayerRaycastController>().questsManager.Activate(questName);
            FindObjectOfType<PlayerRaycastController>().questsGuiManager.UpdateGUI();
		}
	}
	public void LoadGhouls()
    {
        PlayerRaycastController.ghoulsKilled = PlayerPrefs.GetInt("GhoulsKilled", 0);
	}
    /// <summary>
    /// Loading players money from PlayerPrefs variable 'Money'
    /// </summary>
    public void LoadMoney()
    {
        GameManager.money = PlayerPrefs.GetInt("Money", 0);
    }

    /// <summary>
    /// Saving state of players position, inventory and money
    /// </summary>
    public void Save()
    {
		SavePlayersPosition();
		SavePlayersInventory();
        SaveMoney();
        SaveGhouls();
        SaveCurrentQuest();
	}
	

	/// <summary>
	/// Loading state of players position, inventory and money
	/// </summary>
	public void Load()
	{
		LoadPlayersPosition();
		LoadPlayersInventory();
        LoadMoney();
        LoadGhouls();
        LoadCurrentQuest();
	}

	public static void ResetState()
	{
		PlayerPrefs.SetString("PlayerPosition", "");
		PlayerPrefs.SetString("PlayersInventory", "");
		PlayerPrefs.SetInt("Money", 0);
		PlayerPrefs.SetInt("GhoulsKilled", 0);
        PlayerPrefs.SetString("CurrentQuest", "");
	}
}
