using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Scene_one_controller : MonoBehaviour
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
    /// <summary>
    /// Amount of ghouls killed
    /// </summary>

    public static int ghoulsKilled;

    /// <summary>
    /// Quests manager, containing all the informations about quests
    /// </summary>
    public QuestsManager questsManager;

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
            //Checking if Doors are in front of us
            if (hit.transform.gameObject.name == "Door" && hit.distance <= 2)
            {
                //Displaying text on UI to click E to open door
                InfoTextUI.Instance.ShowInfo("Click [E] to open the door");
                //Going to next scene (inside of house) on clicking E key
                if (Input.GetKeyDown(KeyCode.E))
                {
                    StartCoroutine(GoToNextScene(1));
                }
            
                //Checking if Ghoul is in front of us
            }else if(hit.transform.gameObject.name == "Ghoul")
            {
                
                bool isDead = hit.transform.gameObject.GetComponent<Ghoul>().IsDead;
                if (isDead == false)
                {
                    AimController.Instance.ChangeAimSprite(false);
                    //Displaying text on UI to click left mouse button to kill GHOUL
                    InfoTextUI.Instance.ShowInfo("Click [LMB] to kill Ghoul");
                    //Killing ghoul on clicking left mouse button
                    if (Input.GetMouseButtonDown(0) && (WeaponManager.Instance.CurrentWeapon.IsMelee || WeaponManager.Instance.CurrentWeapon.Ammo > 0))
                    {
                        hit.transform.gameObject.GetComponent<Animation>().Play("Death");
                        hit.transform.gameObject.GetComponent<Ghoul>().IsDead = true;
                        ghoulsKilled++;
                        questsManager.GetQuestByName("Main Quest").GetTaskByName("Kill Zombies").CurrentProgress++;
                        StartCoroutine(RemoveGhoulFromScene(hit.transform.gameObject));
                    }
                }
            }
            else if(hit.transform.gameObject.GetComponent<Purchasable>() != null && hit.distance <= 5)
            {
                //Performing actions once player aims on purchasable item, displaying UI informing player about possible actions he can do with this item
                Purchasable purchasable = hit.transform.gameObject.GetComponent<Purchasable>();
                if (GameManager.money < purchasable.Price)
                    InfoTextUI.Instance.ShowInfo($"You need {purchasable.Price} money to purchase {purchasable.Name}");
                else
                {
                    InfoTextUI.Instance.ShowInfo($"Click [Q] if you wanna purchase {purchasable.Name}");
                    //If player clicks Q key, he will purchase item for money he collected
                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        GameManager.money -= purchasable.Price;
                        purchasable.OnPurchase();
                        StartCoroutine(InfoTextUI.Instance.ShowInfo($"You purchased {purchasable.Name}", 1));
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
    //Setting transition between scenes and going to next scene
    IEnumerator RemoveGhoulFromScene(GameObject ghoul)
    {
        yield return new WaitForSeconds(2);
        //Instantiating reward for killing ghoul
        Transform coinTransform = ghoul.transform;
        Instantiate(coin, new Vector3(coinTransform.position.x + 1, coinTransform.position.y + 2, coinTransform.position.z), Quaternion.Euler(-90,0,0));
        Destroy(ghoul);
    }
    /// <summary>
    /// Going to next scene
    /// </summary>
    /// <param name="sceneIndex">Index of scene to go to</param>
    /// <returns></returns>
    public IEnumerator GoToNextScene(int sceneIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        InfoTextUI.Instance.Hide();

        transition.SetTrigger("End");

        SceneManager.LoadScene(sceneIndex);
    }
}
