using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuickSlotsManager : MonoBehaviour
{
    public QuickSlot[] Slots;

    void Start()
    {
        Slots = transform.GetComponentsInChildren<QuickSlot>();
        for(int i = 1; i < Slots.Length + 1; i++)
        {
            Slots[i-1].Id = i;
        }
    }

    public Transform AssignToSlot()
    {
        var freeSlot = Slots.FirstOrDefault(a => a.IsEmpty);
        if (freeSlot != null)
        {
            return freeSlot.transform;
        }
        return null;
    }

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
