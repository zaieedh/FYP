using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskGui : MonoBehaviour
{
    public QuestTask QuestTask { get; set; }
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
