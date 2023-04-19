using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuickSlotsManager : MonoBehaviour
{
    /// <summary>
    /// Array of QuickSlots
    /// </summary>
    public QuickSlot[] Slots;

    void Awake()
    {
        Slots = transform.GetComponentsInChildren<QuickSlot>();
        for(int i = 1; i < Slots.Length + 1; i++)
        {
            Slots[i-1].Id = i;
        }
    }
    /// <summary>
    /// Searching for first empty slot and returning its transform
    /// </summary>
    /// <returns>Transform of first empty slot</returns>
    public Transform AssignToSlot()
    {
        var freeSlot = Slots.FirstOrDefault(a => a.IsEmpty);
        if (freeSlot != null)
        {
            return freeSlot.transform;
        }
        return null;
    }
    /// <summary>
    /// Searching for first slot that has given Id
    /// </summary>
    /// <param name="id">Id of searched slot</param>
    /// <returns>Transform of slot with given id</returns>
    public Transform GetItemAtId(int id)
    {
        var slot = Slots.FirstOrDefault(a => a.Id == id);
        if(slot != null)
        {
            return slot.transform;
		}
        return null;
    }
}
