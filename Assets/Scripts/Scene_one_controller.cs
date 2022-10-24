using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_one_controller : MonoBehaviour
{
    public Transform cameraObject, doorText, ghoulText;
    public Animator transition;
    public Animation ghoulDeathAnimation;

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
            if (hit.transform.gameObject.name == "Door")
            {
                ghoulText.gameObject.SetActive(false);
                doorText.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    StartCoroutine(GoToNextScene(1));
                }
            }else if(hit.transform.gameObject.name == "Ghoul")
            {
                doorText.gameObject.SetActive(false);
                ghoulText.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.R))
                {
                    hit.transform.gameObject.GetComponent<Animation>().Play("Death");
                    Debug.Log("Ghoul killed! Good job!");
                }
            }
            else
            {
                ghoulText.gameObject.SetActive(false);
                doorText.gameObject.SetActive(false);
            }
        }
        else
        {
            ghoulText.gameObject.SetActive(false);
            doorText.gameObject.SetActive(false);
        }
    }

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
