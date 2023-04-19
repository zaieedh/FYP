using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum QuestTaskType
{
	Progressable,
	Triggerable,
	Other
}

[Serializable]
public class QuestTask
{
	/// <summary>
	/// Name of task
	/// </summary>
	public string Name;
	/// <summary>
	/// Description of task
	/// </summary>
	public string Description;
	/// <summary>
	/// Type of task
	/// </summary>
	public QuestTaskType Type;
	/// <summary>
	/// Current progress of task
	/// </summary>
	public int CurrentProgress;
	/// <summary>
	/// Required progress of task (once current progress equals required progress, task is marked as completed)
	/// </summary>
	public int RequiredProgress;
	/// <summary>
	/// Checking if task is completed
	/// </summary>
	public bool IsCompleted;
	/// <summary>
	/// Updating task progress (For progressable tasks)
	/// </summary>
	/// <param name="d">Value of progress to be increased by</param>
	public void UpdateProgress(int d)
	{
		CurrentProgress+=d;
		if (CurrentProgress >= RequiredProgress)
		{
			IsCompleted = true;
		}
	}
	/// <summary>
	/// Updating task progress (For progressable tasks)
	/// </summary>
	/// <param name="d">Value of progress to be set up</param>
	public void SetProgress(int d)
	{
		CurrentProgress = d;
		if (CurrentProgress >= RequiredProgress)
		{
			IsCompleted = true;
		}
	}
}
