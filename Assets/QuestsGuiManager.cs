using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestsGuiManager : MonoBehaviour
{
	public GameObject QuestTaskGuiPrefab;
	public GameObject QuestGuiPrefab;
	private QuestsManager questsManager;
	private void Awake()
	{
		//DontDestroyOnLoad(this);
	}
	private void Start()
	{
		questsManager = FindObjectOfType<Scene_one_controller>().questsManager;
		ResetGUI();
	}

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
