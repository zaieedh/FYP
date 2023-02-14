using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasScript : MonoBehaviour
{
	private static CanvasScript instance;
	public static CanvasScript Instance { get { return instance; } }
	private void Awake()
	{
		if(instance == null)
			instance = this;
	}
	void Start()
    {
		DontDestroyOnLoad(gameObject);
    }
}
