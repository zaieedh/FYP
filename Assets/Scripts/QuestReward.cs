using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestRewardType
{
	Coins,
	Item,
	Other
}
[Serializable]
public class QuestReward
{
	/// <summary>
	/// Name of reward
	/// </summary>
	public string Name;
	/// <summary>
	/// Type of reward
	/// </summary>
	public QuestRewardType Type;
	/// <summary>
	/// Prefab of item to be given as a reward for completing the task
	/// </summary>
	public Purchasable ItemRewardPrefab;
}
