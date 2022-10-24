using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenScript : MonoBehaviour
{
    public GameObject door;
    private bool opened;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!opened)
                OpenDoor();
            else
                CloseDoor();
        }
    }

    public void OpenDoor()
    {
        door.transform.localRotation = Quaternion.Euler(new Vector3(0, -90, 0));
        opened = true;
    }

    public void CloseDoor()
    {
        door.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        opened = false;
    }
}
