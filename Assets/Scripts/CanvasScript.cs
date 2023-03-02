using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasScript : MonoBehaviour
{
	/// <summary>
	/// Instance of canvas script
	/// </summary>
	private static CanvasScript instance;
	public static CanvasScript Instance { get { return instance; } }
	private void Awake()
	{
		if(instance == null)
			instance = this;
	}
	void Start()
    {
		//Preventing canvas to be destroyed on load
		DontDestroyOnLoad(gameObject);
    }
}
