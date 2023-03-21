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
        }else if(Type == DoorType.GameEnd)
        {
			SceneManager.LoadScene(3);
			//gameManager.GoToNextScene(0);
		}
        OnDoorOpening();
	}

    private void OnDoorOpening()
    {
        if(gameObject.name == "DoorToLocationTwo")
        {
			var sceneOneController = FindObjectOfType<Scene_one_controller>();
            sceneOneController.questsManager.Activate("Second Quest");
            sceneOneController.questsGuiManager.ResetGUI();
		}
        else if (gameObject.name == "DoorToLocationTwo")
		{

		}
	}

    private void OpenDoorByRotating()
    {

    }


}
