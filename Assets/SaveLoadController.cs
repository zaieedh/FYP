using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class SaveLoadController : MonoBehaviour
{
	public GameObject[] PurchasablePrefabs;

    // Start is called before the first frame update
    void Start()
    {
        Load();
    }

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

    public void SavePlayersPosition()
    {
        var playerPosition = FindObjectOfType<PlayerScript>().transform.position;
        PlayerPrefs.SetString("PlayerPosition", $"{playerPosition.x};{playerPosition.y};{playerPosition.z}");
    }

    public void SavePlayersInventory()
    {
		var inventory = FindObjectOfType<InventoryScript>();
		var itemsNames = string.Join(";", inventory.GetNamesOfInventoryItems());
        PlayerPrefs.SetString("PlayersInventory", itemsNames);
	}

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

    public void SaveMoney()
    {
        PlayerPrefs.SetInt("Money", GameManager.money);
    }

    public void LoadMoney()
    {
        GameManager.money = PlayerPrefs.GetInt("Money", 0);
    }

    public void SaveEnemiesState()
    {

    }

    public void LoadEnemiesState()
    {

    }

    public void Save()
    {
		SavePlayersPosition();
		SavePlayersInventory();
        SaveMoney();
	}

	public void Load()
	{
		LoadPlayersPosition();
		LoadPlayersInventory();
        LoadMoney();
	}
}
