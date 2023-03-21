using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	/// <summary>
	/// Audio souce assigned to main menu
	/// </summary>
	AudioSource startingNoise;
	//Loads Next Scene
	void Awake()
	{
		startingNoise = GetComponent<AudioSource>();
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	/// <summary>
	/// Starting a game
	/// </summary>
	public void ButtonHandlerPlay()
	{
		StartCoroutine(PlaySoundAndStartGame());
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	/// <summary>
	/// Playing sound on game start
	/// </summary>
	/// <returns></returns>
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
