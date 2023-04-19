using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum DoorType
{
    ChangeLocation,
    Rotate,
    GameEnd,
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
    /// Check if door requires password to open
    /// </summary>
    public bool RequiresPassword;
    /// <summary>
    /// Password to open doors;
    /// </summary>
    public string Password;
    /// <summary>
    /// Key to open this door
    /// </summary>
    public Purchasable Key;
    /// <summary>
    /// Main game manager
    /// </summary>
    private GameManager gameManager;
	private void Start()
	{
        gameManager = FindObjectOfType<GameManager>();	
	}

    /// <summary>
    /// Function used to open the door, based on its type, behaving will be different
    /// For ChangeLocation type:
    /// - Player will be moved to TargetLocation
    /// For Rotate type:
    /// - Door will rotate, to be opened
    /// For GameEnd:
    /// - Game will end once door is opened
    /// </summary>
	public void Open()
    {
        if(Type == DoorType.ChangeLocation)
        {
          
            gameManager.GoToNextLocation(TargetLocation);
        }else if(Type == DoorType.Rotate)
        {
            OpenDoorByRotating();
        }else if(Type == DoorType.GameEnd)
        {
			SceneManager.LoadScene(3);
		}
        OnDoorOpening();
	}
    /// <summary>
    /// Action to be performed when door open
    /// </summary>
    private void OnDoorOpening()
    {
        //Checking if door name is DoorToLocationTwo
        if(gameObject.name == "DoorToLocationTwo")
        {
            //Finding PlayerRaycastController and setting up Second Quest as Active, at the end reseting GUI so Quest gui will update
			var playerRaycastController = FindObjectOfType<PlayerRaycastController>();
            playerRaycastController.questsManager.Activate("Second Quest");
            playerRaycastController.questsGuiManager.ResetGUI();
		}
	}
    /// <summary>
    /// Action to be performed when door is opening by rotation
    /// </summary>
    private void OpenDoorByRotating()
    {
        Debug.Log("Door is opened by rotating");
    }


}
