using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuScript : MonoBehaviour
{
    /// <summary>
    /// Closing game, quiting application
    /// </summary>
    public void CloseGame()
    {
        Application.Quit();
    }
    /// <summary>
    /// Closing menu
    /// </summary>
    public void CloseMenu()
    {
        GameManager.isMenuOpened = false;
        gameObject.SetActive(false);
    }
}
