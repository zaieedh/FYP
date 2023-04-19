using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenController : MonoBehaviour
{
    /// <summary>
    /// Reference to text displayign info about the number of ghouls killed
    /// </summary>
    public TextMeshProUGUI KilledGhoulsText;
	

	void Start()
    {
        KilledGhoulsText.text = $"You killed {PlayerPrefs.GetInt("GhoulsKilled")} enemies!";
    }
    /// <summary>
    /// Opening main menu scene
    /// </summary>
    public void GoToMainMenu()
    {
		SceneManager.LoadScene(0);
		

	}
    /// <summary>
    /// Restarting the game
    /// </summary>
    public void RestartGame()
    {
	    PlayerPrefs.SetInt("GhoulsKilled", 0);
		PlayerPrefs.SetString("CurrentQuest", "");
		PlayerPrefs.SetInt("Money", 0);
		PlayerPrefs.SetString("PlayersInventory", "");
        PlayerPrefs.SetString("PlayerPosition", "");
		SceneManager.LoadScene(1);
	}
}
