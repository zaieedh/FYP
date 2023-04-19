using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestGui : MonoBehaviour
{
	/// <summary>
	/// Reference to quest object
	/// </summary>
	public Quest Quest;
	/// <summary>
	/// Updating quest GUI
	/// </summary>
	public void UpdateGui()
	{
		gameObject.transform.Find("QuestName").GetComponentInChildren<TextMeshProUGUI>().text = Quest.Name;
	}
	/// <summary>
	/// Adding Task to GUI from list of active tasks from Quest object
	/// </summary>
	/// <param name="task">Prefab of task object to be added to list</param>
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
