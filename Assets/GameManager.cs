using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Main menu object
    /// </summary>
    public GameObject MainMenu;
    /// <summary>
    /// Checking if menu is opened
    /// </summary>
    private static bool _menuOpened;
    /// <summary>
    /// Setting state of menu and returning it
    /// </summary>
    public static bool isMenuOpened
    {
        get
        {
            return _menuOpened;
        }
        set
        {
            _menuOpened = value;
            if (_menuOpened)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
        }
    }
    /// <summary>
    /// Money collected by user
    /// </summary>
    public static int money;
    // Update is called once per frame
    void Update()
    {
        //Open menu when player clicks ESC key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isMenuOpened = !isMenuOpened;
            MainMenu.SetActive(!MainMenu.activeSelf);
        }
    }
}
