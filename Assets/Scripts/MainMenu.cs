using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	AudioSource startingNoise;
	//Loads Next Scene
	void Awake()
	{
		startingNoise = GetComponent<AudioSource>();
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	private void Start()
	{
		Debug.Log("In start");
		DestroyImmediate(CanvasScript.Instance.gameObject);
	}

	public void ButtonHandlerPlay()
	{

		StartCoroutine(PlaySoundAndStartGame());
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);



	}
	IEnumerator PlaySoundAndStartGame()
	{
		startingNoise.Play();

		yield return new WaitForSeconds(startingNoise.clip.length);
		
		//	SceneManager.LoadSceneAsync(1);
	}
	//Game comes to a end
	public void Quit()
	{
		Application.Quit();
		Debug.Log("Quit");
	}
}
