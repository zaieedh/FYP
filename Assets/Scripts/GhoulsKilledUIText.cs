using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//Updating score of killed Ghouls on UI
public class GhoulsKilledUIText : MonoBehaviour
{
	private PlayerRaycastController controller;

	private void Start()
	{
		controller = FindObjectOfType<PlayerRaycastController>();
	}
	void Update()
	//PlayerRaycastController.ghoulsKilled.ToString()
	{
		//Updating UI with amount of ghouls killed
		GetComponent<TextMeshProUGUI>().text = "Ghouls killed: " + controller.ghoulsKilled.ToString();
    }
}
