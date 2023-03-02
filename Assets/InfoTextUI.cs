using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoTextUI : MonoBehaviour
{
    /// <summary>
    /// Text object that appears on the screen when info is displayed
    /// </summary>
    TextMeshProUGUI text;
    /// <summary>
    /// Info of TextUI class
    /// </summary>
    public static InfoTextUI Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        //Assinging text object, from children of InfoTextUI gameobject
        text = GetComponentInChildren<TextMeshProUGUI>();
        //Hiding info
        Hide();
    }
    /// <summary>
    /// Showing UI info on screen
    /// </summary>
    /// <param name="content">Content of info</param>
    public void ShowInfo(string content)
    {
        text.text = content;
        gameObject.SetActive(true);
    }
    /// <summary>
    /// Showing UI info on screen that automatically disapears
    /// </summary>
    /// <param name="content">Content of info</param>
    /// <param name="seconds">Amount of seconds after which info will disapear</param>
    /// <returns></returns>
    public IEnumerator ShowInfo(string content, int seconds)
    {
        ShowInfo(content);
        yield return new WaitForSeconds(seconds);
        Hide();
    }
    /// <summary>
    /// Hiding info
    /// </summary>
    public void Hide()
    {
        text.text = "";
        gameObject.SetActive(false);
    }
}
