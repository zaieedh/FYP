using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoTextUI : MonoBehaviour
{
    TextMeshProUGUI text;
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

        text = GetComponentInChildren<TextMeshProUGUI>();
        Hide();
    }

    public void ShowInfo(string content)
    {
        text.text = content;
        gameObject.SetActive(true);
    }

    public IEnumerator ShowInfo(string content, int seconds)
    {
        ShowInfo(content);
        yield return new WaitForSeconds(seconds);
        Hide();
    }

    public void Hide()
    {
        text.text = "";
        gameObject.SetActive(false);
    }
}
