using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum DoorType
{
    ChangeLocation,
    Rotate,
    Other
}
public class Door : MonoBehaviour
{
    /// <summary>
    /// Door type
    /// </summary>
    public DoorType Type;
    /// <summary>
    /// Scene of index, for changing location
    /// </summary>
    public int SceneIndex;
    /// <summary>
    /// Name of location to move after opening door
    /// </summary>
    public string TargetLocation;
    /// <summary>
    /// Check if door requires key
    /// </summary>
    public bool RequiresKey;
    /// <summary>
    /// Key to open this door
    /// </summary>
    public Purchasable Key;

    private GameManager gameManager;
	private void Start()
	{
        gameManager = FindObjectOfType<GameManager>();	
	}
	public void Open()
    {
        if(Type == DoorType.ChangeLocation)
        {
            //gameManager.GoToNextScene(SceneIndex);
            gameManager.GoToNextLocation(TargetLocation);
        }else if(Type == DoorType.Rotate)
        {
            OpenDoorByRotating();
            Debug.Log("Door is opening");
        }
    }

    private void OpenDoorByRotating()
    {

    }
}
