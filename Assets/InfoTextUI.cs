using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoTextUI : MonoBehaviour
{
    TextMeshProUGUI text; 
    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        gameObject.SetActive(false);
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
