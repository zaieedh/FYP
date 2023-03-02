using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//Updating score of killed Ghouls on UI
public class GhoulsKilledUIText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Updating UI with amount of ghouls killed
        GetComponent<TextMeshProUGUI>().text = "Ghouls killed: " + Scene_one_controller.ghoulsKilled.ToString();
    }
}
