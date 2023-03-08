using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	/// <summary>
	/// Animator of scene transitions
	/// </summary>
	public Animator transition;
	/// <summary>
	/// Main menu object
	/// </summary>
	public GameObject MainMenu;
    /// <summary>
    /// Checking if menu is opened
    /// </summary>
    private static bool _menuOpened;
    /// <summary>
    /// Setting state of menu and returning it
    /// </summary>
    public static bool isMenuOpened
    {
        get
        {
            return _menuOpened;
        }
        set
        {
            _menuOpened = value;
            if (_menuOpened)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
        }
    }
    /// <summary>
    /// Money collected by user
    /// </summary>
    public static int money;

    void Update()
    {
        //Open menu when player clicks ESC key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isMenuOpened = !isMenuOpened;
            MainMenu.SetActive(!MainMenu.activeSelf);
        }
    }

    public void GoToNextScene(int id)
    {
        StartCoroutine(goToNextScene(id));
    }

	/// <summary>
	/// Going to next scene
	/// </summary>
	/// <param name="sceneIndex">Index of scene to go to</param>
	/// <returns></returns>
	private IEnumerator goToNextScene(int sceneIndex)
	{
		transition.SetTrigger("Start");

		yield return new WaitForSeconds(1);

		InfoTextUI.Instance.Hide();

		transition.SetTrigger("End");

		SceneManager.LoadScene(sceneIndex);
	}

    public void GoToNextLocation(string location)
    {
        StartCoroutine(goToNextLocation(location));
    }

    private IEnumerator goToNextLocation(string location)
    {
		transition.SetTrigger("Start");

		yield return new WaitForSeconds(1);
		var spawnPoint = FindObjectOfType<LocationsManager>().GetLocationByName(location).SpawnPoint.position;
		FindObjectOfType<PlayerScript>().MoveTo(spawnPoint);
		InfoTextUI.Instance.Hide();

		transition.SetTrigger("End");

        
	}
}
