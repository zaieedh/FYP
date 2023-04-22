using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerRaycastController : MonoBehaviour
{
    /// <summary>
    /// Instance of coin gameobject
    /// </summary>
    public GameObject coin;
    /// <summary>
    /// Animator of scene transitions
    /// </summary>
    public Animator transition;
    /// <summary>
    /// Animation played once ghould dying
    /// </summary>
    public Animation ghoulDeathAnimation;
    
    /// <summary>
    /// Players hit distance on close aim mode
    /// </summary>
    public float hitDistanceClose = 5;
    /// <summary>
    /// Players hit distance on far aim mode
    /// </summary>
    public float hitDistanceFar = 50;
    private static int _ghoulsKilled;
    /// <summary>
    /// Amount of ghouls killed
    /// </summary>

    public static int ghoulsKilled
    {
        get
        {
            return _ghoulsKilled;
        }
        set
        {
            _ghoulsKilled = value;
            PlayerPrefs.SetInt("GhoulsKilled", _ghoulsKilled);
        }
    }

    /// <summary>
    /// Quests manager, containing all the informations about quests
    /// </summary>
    public QuestsManager questsManager;

	/// <summary>
	/// Quests GUI manager, display on GUI informations about quests
	/// </summary>
	public QuestsGuiManager questsGuiManager;
    /// <summary>
    /// GameManager instance with functionalities used in many classes
    /// </summary>
    public GameManager gameManager;
    public GameObject doorInputLocker;

	private void Start()
	{
        Debug.Log("Test!");
	}

	private void FixedUpdate()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(PlayerCam.Instance.transform.position, PlayerCam.Instance.transform.TransformDirection(Vector3.forward), out hit, WeaponManager.Instance.CurrentWeapon.Range, layerMask))
        {
            var hitObject = hit.transform.gameObject;

            //if enemy is pointed at follwoing ir run
			if (hitObject.GetComponent(typeof(Enemy)) != null)
            {
                Enemy enemy = (hitObject.GetComponent(typeof(Enemy)) as Enemy);

				bool isDead = enemy.IsDead;
                if (isDead == false)
                {
                    AimController.Instance.ChangeAimSprite(false);
                    //Displaying text on UI to click left mouse button to kill GHOUL
                    InfoTextUI.Instance.ShowInfo($"Click [LMB] to attack {enemy.Name}");
                    //Killing ghoul on clicking left mouse button
                    if (Input.GetMouseButtonDown(0) && (WeaponManager.Instance.CurrentWeapon.IsMelee || WeaponManager.Instance.CurrentWeapon.Ammo > 0))
                    {
						enemy.TakeDamage(WeaponManager.Instance.CurrentWeapon.Damage);
                        if (enemy.IsDead)
                        {
                            if (enemy.Name == "Ghoul")
                            {
                                ghoulsKilled++;
                                questsManager.GetQuestByName("Main Quest").GetTaskByName("Kill 5 Zombies").UpdateProgress(1);
                            }
                            else if (enemy.Name == "Big Boss")
                            {
								ghoulsKilled++;
								questsManager.GetQuestByName("Main Quest").GetTaskByName("Kill Zombie Boss").IsCompleted = true;
                            }
							else if (enemy.Name == "DesertEnemy" || (enemy.Name == "E2") || (enemy.Name == "HouseEnemy"))
							{
								ghoulsKilled++;
								
							}
                            //Checks for data inQuestManager ans displayes on GUI
							questsGuiManager.UpdateGUI();
						}
                    }
                }
            }
            //if something in shop or item
            else if(hitObject.GetComponent<Purchasable>() != null && hit.distance <= 5)
            {
                //Performing actions once player aims on purchasable item, displaying UI informing player about possible actions he can do with this item
                Purchasable purchasable = hit.transform.gameObject.GetComponent<Purchasable>();
                if (GameManager.money < purchasable.Price)
                    InfoTextUI.Instance.ShowInfo($"You need {purchasable.Price} gold to purchase {purchasable.Name} {purchasable.Info}");
                else
                {
                    if(purchasable.Price == 0)
                    {
						InfoTextUI.Instance.ShowInfo($"Click [P] to pick up {purchasable.Name} {purchasable.Info}");
                    }
                    else
                    {
						InfoTextUI.Instance.ShowInfo($"Click [P] if you want to purchase {purchasable.Name} {purchasable.Info}");
					}
                    
                    //If player clicks P key, he will purchase item for money he collected
                    if (Input.GetKeyDown(KeyCode.P))
                    {
                        GameManager.money -= purchasable.Price;
                        purchasable.OnPurchase();
                        if(purchasable.Price > 0)
                            StartCoroutine(InfoTextUI.Instance.ShowInfo($"You purchased {purchasable.Name} {purchasable.Info}", 1));
                    }
                }
            }
			else if (hitObject.GetComponent<Door>() != null && hit.distance <= 2)
			{
                //Performing actions once player aims on any door
				var door = hit.transform.gameObject.GetComponent<Door>();
                if (door.RequiresKey)
                {
					InfoTextUI.Instance.ShowInfo($"Find [{door.Key.Name}] to open the door");
                    Purchasable key = FindObjectOfType<InventoryScript>().GetInventoryItemByName(door.Key.Name);
                    if(key != null)
                    {
						//Displaying text on UI to click E to open door
						InfoTextUI.Instance.ShowInfo("Click [E] to open the door");
						//Going to next location on clicking E key
						if (Input.GetKeyDown(KeyCode.E))
						{
							door.Open();
						}
					}
				}else if (door.RequiresPassword)
                {
					//Displaying text on UI to click E to open door
					InfoTextUI.Instance.ShowInfo("Click Q to input code");
					//Going to next scene (inside of house) on clicking E key
					if (Input.GetKeyDown(KeyCode.Q))
					{
						doorInputLocker.SetActive(true);
                        Time.timeScale = 0;
                        var doorIL = doorInputLocker.GetComponent<DoorInputLocker>();
						door.Password = FindObjectOfType<RussianRadioCheckpoint>().TopSecretCode.ToString();
                        doorIL.Door = door;
                        doorIL.ActivateInput();
					}
				}
                else
                {
                    //Displaying text on UI to click E to open door
                    InfoTextUI.Instance.ShowInfo("Click [E] to open the door");
                    //Going to next scene (inside of house) on clicking E key
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        door.Open();
                    }
                }
			}
			else
            {
                InfoTextUI.Instance.Hide();
                AimController.Instance.ChangeAimSprite(true);
            }
        }
        else
        {
            InfoTextUI.Instance.Hide();
            AimController.Instance.ChangeAimSprite(true);
        }
        
    }
    
}
