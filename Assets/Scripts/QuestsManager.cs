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

	public void Activate(string name)
	{
		foreach(Quest a in Quests.Where(b => b.Name != name))
		{
			a.IsActive = false;
		}
		GetQuestByName(name).IsActive = true;
	}
}
