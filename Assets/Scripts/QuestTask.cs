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
	public string Name;
	public string Description;
	public QuestTaskType Type;
	public int CurrentProgress;
	public int RequiredProgress;
	public bool IsCompleted;

	public void UpdateProgress(int d)
	{
		CurrentProgress+=d;
		if (CurrentProgress >= RequiredProgress)
		{
			IsCompleted = true;
		}
	}
}
