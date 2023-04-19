using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class Quest
{
	/// <summary>
	/// Name of quest
	/// </summary>
	public string Name;
	/// <summary>
	/// Order of quest on quests list
	/// </summary>
	public int Order;
	/// <summary>
	/// List of Tasks in quest
	/// </summary>
	public List<QuestTask> Tasks;
	/// <summary>
	/// Reward for completing quest
	/// </summary>
	public QuestReward QuestReward;
	/// <summary>
	/// Checking if all Tasks in quest are completed
	/// </summary>
	public bool IsCompleted
	{
		get
		{
			return Tasks.All(a=>a.IsCompleted);
		}
	}
	/// <summary>
	/// Checking if quest is active
	/// </summary>
	public bool IsActive;
	/// <summary>
	/// Returing QuestTask by its name
	/// </summary>
	/// <param name="name">Name of quest task</param>
	/// <returns>Quest task</returns>
	public QuestTask GetTaskByName(string name)
	{
		return Tasks.FirstOrDefault(a => a.Name == name);
	}
}
