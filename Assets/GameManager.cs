using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject MainMenu;
    private static bool _menuOpened;
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
    public static int money;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isMenuOpened = !isMenuOpened;
            MainMenu.SetActive(!MainMenu.activeSelf);
        }
    }
}
