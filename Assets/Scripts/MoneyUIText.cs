using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyUIText : MonoBehaviour
{
    void Update()

        //+ GameManager.money.ToString()
    {
		//Updating money UI text
		GetComponent<TextMeshProUGUI>().text = "Money: " + GameManager.money.ToString();
    }
}
