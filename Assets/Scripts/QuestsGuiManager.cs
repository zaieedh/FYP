using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestsGuiManager : MonoBehaviour
{
	/// <summary>
	/// Prefab of QuestTask object on GUI
	/// </summary>
	public GameObject QuestTaskGuiPrefab;
	/// <summary>
	/// Prefab of Quest object on GUI
	/// </summary>
	public GameObject QuestGuiPrefab;
	/// <summary>
	/// Reference to QuestsManager
	/// </summary>
	private QuestsManager questsManager;

	private void Start()
	{
		questsManager = FindObjectOfType<PlayerRaycastController>().questsManager;
		ResetGUI();
	}

	/// <summary>
	/// Reseting GUI, destroying all of quests items on GUI and instantiating them again based on current quests/tasks and its progress
	/// </summary>
	public void ResetGUI()
	{
		foreach(Transform tf in transform)
		{
			Destroy(tf.gameObject);
		}

		foreach (Quest quest in questsManager.Quests.Where(a=>a.IsActive).OrderByDescending(a=>a.Order))
		{
			var questGui = Instantiate(QuestGuiPrefab, transform);
			questGui.GetComponent<QuestGui>().Quest = quest;
			questGui.GetComponent<QuestGui>().UpdateGui();
			questGui.GetComponent<QuestGui>().AddTasks(QuestTaskGuiPrefab);
		}
	}
	/// <summary>
	/// Updating quests and tasks on GUI
	/// </summary>
	public void UpdateGUI()
	{
		ResetGUI();
		foreach(QuestGui qg in FindObjectsOfType<QuestGui>())
		{
			qg.UpdateGui();
		}
		foreach (TaskGui qt in FindObjectsOfType<TaskGui>())
		{
			qt.UpdateGui();
		}
	}
}
