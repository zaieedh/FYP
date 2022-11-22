using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public void CloseGame()
    {
        Application.Quit();
    }

    public void CloseMenu()
    {
        GameManager.isMenuOpened = false;
        gameObject.SetActive(false);
    }

    public void OpenShop()
    {
        Debug.Log("Open shop clicked");
    }
}
