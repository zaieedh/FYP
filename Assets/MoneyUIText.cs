using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyUIText : MonoBehaviour
{
    void Update()
    {
        //Updating money UI text
        GetComponent<TextMeshProUGUI>().text = "Money: " + Scene_one_controller.money.ToString();
    }
}
