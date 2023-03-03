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
	public string Name;
	public QuestRewardType Type;
	public Purchasable ItemRewardPrefab;
}
