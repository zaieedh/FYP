using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_one_controller : MonoBehaviour
{
    public Transform cameraObject, doorText, ghoulText;
    public Animator transition;
    public Animation ghoulDeathAnimation;

    public static int ghoulsKilled;

    private void FixedUpdate()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(cameraObject.position, cameraObject.TransformDirection(Vector3.forward), out hit, 2f, layerMask))
        {
            //Checking if Doors are in front of us
            if (hit.transform.gameObject.name == "Door")
            {
                //Displaying text on UI to click E to open door
                doorText.gameObject.SetActive(true);
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
                    //Displaying text on UI to click left mouse button to kill GHOUL
                    ghoulText.gameObject.SetActive(true);
                    //Killing ghoul on clicking left mouse button
                    if (Input.GetMouseButtonDown(0))
                    {
                        hit.transform.gameObject.GetComponent<Animation>().Play("Death");
                        hit.transform.gameObject.GetComponent<Ghoul>().IsDead = true;
                        ghoulsKilled++;
                    }
                }
            }
            else
            {
                //Hiding UI tips when we dont point on Ghoul or Doors
                ghoulText.gameObject.SetActive(false);
                doorText.gameObject.SetActive(false);
            }
        }
        else
        {
            //Hiding UI tips when we dont point on any object
            ghoulText.gameObject.SetActive(false);
            doorText.gameObject.SetActive(false);
        }
    }
    //Setting transition between scenes and going to next scene
    IEnumerator GoToNextScene(int sceneIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        ghoulText.gameObject.SetActive(false);
        doorText.gameObject.SetActive(false);

        transition.SetTrigger("End");

        SceneManager.LoadScene(sceneIndex);

        
    }
}
