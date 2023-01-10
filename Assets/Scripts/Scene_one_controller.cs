using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Scene_one_controller : MonoBehaviour
{
    public InfoTextUI infoTextUI;
    public GameObject coin;
    public Animator transition;
    public Animation ghoulDeathAnimation;
    
    
    public float hitDistanceClose = 5;
    public float hitDistanceFar = 50;

    public static int ghoulsKilled;

    private void Start()
    {
        
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
            //Checking if Doors are in front of us
            if (hit.transform.gameObject.name == "Door" && hit.distance <= 2)
            {
                //Displaying text on UI to click E to open door
                infoTextUI.ShowInfo("Click [E] to open the door");
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
                    infoTextUI.ShowInfo("Click [LMB] to kill Ghoul");
                    //Killing ghoul on clicking left mouse button
                    if (Input.GetMouseButtonDown(0))
                    {
                        hit.transform.gameObject.GetComponent<Animation>().Play("Death");
                        hit.transform.gameObject.GetComponent<Ghoul>().IsDead = true;
                        ghoulsKilled++;
                        StartCoroutine(RemoveGhoulFromScene(hit.transform.gameObject));
                    }
                }
            }
            else if(hit.transform.gameObject.GetComponent<Purchasable>() != null && hit.distance <= 5)
            {
                Purchasable purchasable = hit.transform.gameObject.GetComponent<Purchasable>();
                if (GameManager.money < purchasable.Price)
                    infoTextUI.ShowInfo($"You need {purchasable.Price} money to purchase {purchasable.Name}");
                else
                {
                    infoTextUI.ShowInfo($"Click [Q] if you wanna purchase {purchasable.Name}");
                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        GameManager.money -= purchasable.Price;
                        purchasable.OnPurchase();
                        StartCoroutine(infoTextUI.ShowInfo($"You purchased {purchasable.Name}", 1));
                    }
                }
            }
            else
            {
                //Hiding UI tips when we dont point on Ghoul or Doors
                infoTextUI.Hide();
                AimController.Instance.ChangeAimSprite(true);
            }
        }
        else
        {
            //Hiding UI tips when we dont point on any object
            infoTextUI.Hide();
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
    public IEnumerator GoToNextScene(int sceneIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        infoTextUI.Hide();

        transition.SetTrigger("End");

        SceneManager.LoadScene(sceneIndex);
    }
}
