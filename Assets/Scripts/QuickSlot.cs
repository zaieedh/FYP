using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickSlot : MonoBehaviour
{
    /// <summary>
    /// Keyboard key assinged to a slot, once this key is clicked, it will invoke onclick function on item in slot
    /// </summary>
    public KeyCode SlotKey;
    /// <summary>
    /// Id of slot
    /// </summary>
    public int Id;
    /// <summary>
    /// Color of slot
    /// </summary>
    private Color StartColor;
    /// <summary>
    /// Background of slot
    /// </summary>
    private Image Background;
    /// <summary>
    /// Checking if slot is empty
    /// </summary>
    public bool IsEmpty;
    /// <summary>
    /// Item assigned to slot
    /// </summary>
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
    /// <summary>
    /// Assinging item to slot
    /// </summary>
    /// <param name="item">Item to be assigned</param>
    public void AssignItem(GameObject item)
    {
        assignedItem = item;
        IsEmpty = false;
    }
    /// <summary>
    /// Invoking on click function on assigned item
    /// </summary>
    void OnKeyUp()
    {
        if(assignedItem != null)
        {
            assignedItem.GetComponent<Button>().onClick.Invoke();
        }
    }
}
