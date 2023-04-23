using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	/// <summary>
	/// Audio souce assigned to main menu
	/// </summary>
	AudioSource startingNoise;
	public Button VolumeButton;
	public Sprite muteVolumeSprite, unmuteVolumeSprite;

	void Awake()
	{
		startingNoise = GetComponent<AudioSource>();
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	private void Start()
	{
		if (PlayerPrefs.GetInt("IsMuted", 0) == 1)
		{
			foreach (AudioSource audioSource in FindObjectsOfType<AudioSource>())
			{
				audioSource.mute = true;
			}
			VolumeButton.image.sprite = unmuteVolumeSprite;
		}
		else
		{
			foreach (AudioSource audioSource in FindObjectsOfType<AudioSource>())
			{
				audioSource.mute = false;
			}
			VolumeButton.image.sprite = muteVolumeSprite;
		}
		//Remove after tests
		//SaveLoadController.ResetState();
	}

	/// <summary>
	/// Starting a game
	/// </summary>
	public void ButtonHandlerPlay()
	{
		StartCoroutine(PlaySoundAndStartGame());
		var checkIfAnySavePoint = PlayerPrefs.GetString("PlayerPosition", "") != "";
		if (checkIfAnySavePoint)
		{
			SceneManager.LoadScene(1);
		}
		else
		{
			SceneManager.LoadScene(4);
		}
		
	}
	/// <summary>
	/// Playing sound on game start
	/// </summary>
	/// <returns></returns>
	IEnumerator PlaySoundAndStartGame()
	{
		startingNoise.Play();
		yield return new WaitForSeconds(startingNoise.clip.length);
	}
	/// <summary>
	///	Quitting game
	/// </summary>
	public void Quit()
	{
		Application.Quit();
	}

	public void MuteSound()
	{
		if(PlayerPrefs.GetInt("IsMuted", 0) == 1)
		{
			foreach(AudioSource audioSource in FindObjectsOfType<AudioSource>())
			{
				audioSource.mute = false;
			}
			VolumeButton.image.sprite = unmuteVolumeSprite;
			PlayerPrefs.SetInt("IsMuted", 0);
		}
		else
		{
			foreach (AudioSource audioSource in FindObjectsOfType<AudioSource>())
			{
				audioSource.mute = true;
			}
			VolumeButton.image.sprite = muteVolumeSprite;
			PlayerPrefs.SetInt("IsMuted", 1);
		}
		
	}
}
