using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestGui : MonoBehaviour
{
	public Quest Quest;

	public void UpdateGui()
	{
		gameObject.transform.Find("QuestName").GetComponentInChildren<TextMeshProUGUI>().text = Quest.Name;
	}
	public void AddTasks(GameObject task)
	{
		var parent = gameObject.transform.Find("Tasks");

		foreach (QuestTask qt in Quest.Tasks)
		{
			var questTask = Instantiate(task, parent);
			questTask.GetComponent<TaskGui>().QuestTask = qt;
			questTask.GetComponent<TaskGui>().UpdateGui();
		}
	}
}
