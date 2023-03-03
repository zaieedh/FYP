using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class Quest
{
	public string Name;
	public List<QuestTask> Tasks;
	public QuestReward QuestReward;
	public QuestTask GetTaskByName(string name)
	{
		return Tasks.FirstOrDefault(a => a.Name == name);
	}
}
