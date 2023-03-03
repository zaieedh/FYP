using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class QuestsManager
{
	public List<Quest> Quests;
	public Quest GetQuestByName(string name)
	{
		return Quests.FirstOrDefault(a=>a.Name== name);
	}
}
