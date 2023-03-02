using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
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
    /// <summary>
    /// Opening shop
    /// </summary>
    public void OpenShop()
    {
        Debug.Log("Open shop clicked");
    }
}
