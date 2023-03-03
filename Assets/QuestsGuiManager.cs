using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestsGuiManager : MonoBehaviour
{
	public GameObject QuestTaskGuiPrefab;
	public GameObject QuestGuiPrefab;

	private void Start()
	{
		var questsManager = FindObjectOfType<Scene_one_controller>().questsManager;
		foreach(Quest quest in questsManager.Quests)
		{
			var questGui = Instantiate(QuestGuiPrefab, transform);
			questGui.GetComponent<QuestGui>().Quest = quest;
			questGui.GetComponent<QuestGui>().UpdateGui();
			questGui.GetComponent<QuestGui>().AddTasks(QuestTaskGuiPrefab);
		}
	}
}
