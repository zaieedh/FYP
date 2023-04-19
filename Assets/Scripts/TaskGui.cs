using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskGui : MonoBehaviour
{
	/// <summary>
	/// Reference to QuestTask
	/// </summary>
    public QuestTask QuestTask { get; set; }
	/// <summary>
	/// Updating QuestTask GUI based on QuestTask current state
	/// </summary>
	public void UpdateGui()
	{
		gameObject.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = QuestTask.Name;
		if (QuestTask.IsCompleted)
		{
			gameObject.transform.Find("Check").GetComponent<Image>().enabled = true;
		}
		else
		{
			gameObject.transform.Find("Check").GetComponent<Image>().enabled = false;
		}
	}
}
