using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickSlot : MonoBehaviour
{
    public KeyCode SlotKey;
    public int Id;
    private Color StartColor;
    private Image Background;
    public bool IsEmpty;
    private GameObject assignedItem;

	private void Start()
	{
        Background = transform.Find("Background").GetComponent<Image>();
        StartColor = Background.color;
        IsEmpty = true;
	}
	void Update()
    {
        if (Input.GetKey(SlotKey))
        {
            Background.color = Color.white;
        }
        else
        {
            Background.color = StartColor;
        }

        if(Input.GetKeyUp(SlotKey))
        {
            OnKeyUp();
        }
    }

    public void AssignItem(GameObject item)
    {
        assignedItem = item;
        IsEmpty = false;
    }

    void OnKeyUp()
    {
        if(assignedItem != null)
        {
            assignedItem.GetComponent<Button>().onClick.Invoke();
        }
    }
}
