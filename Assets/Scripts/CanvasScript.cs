using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasScript : MonoBehaviour
{
	void Start()
    {
		//Preventing canvas to be destroyed on load
		DontDestroyOnLoad(gameObject);
    }
}
