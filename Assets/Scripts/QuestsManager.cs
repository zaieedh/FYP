using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class QuestsManager
{
	/// <summary>
	/// List of quests
	/// </summary>
	public List<Quest> Quests;
	/// <summary>
	/// Returing quest by its name
	/// </summary>
	/// <param name="name">Name of quest</param>
	/// <returns>Quest</returns>
	public Quest GetQuestByName(string name)
	{
		return Quests.FirstOrDefault(a=>a.Name== name);
	}
	/// <summary>
	/// Setting up quest by its name as active and deactivating other quests
	/// </summary>
	/// <param name="name">Name of quest to be activated</param>
	public void Activate(string name)
	{
		//Marks all of quests as inactive except the one we want to activate
		foreach(Quest a in Quests.Where(b => b.Name != name))
		{
			a.IsActive = false;
		}
		//activating quest we want to active
		GetQuestByName(name).IsActive = true;
	}

	public string GetActiveQuestName()
	{
		return Quests.FirstOrDefault(a=>a.IsActive).Name;
	}
}
