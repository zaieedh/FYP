using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class DoorInputLocker : MonoBehaviour
{
	/// <summary>
	/// Reference to door object
	/// </summary>
    public Door Door;
	/// <summary>
	/// Reference to WrongCodeMessage object on Canvas that is used to display error message while inputing wrong code
	/// </summary>
	public GameObject WrongCodeMessage;

	/// <summary>
	/// Reseting input field and setting timeScale to 1
	/// </summary>
	public void Close()
	{
		GetComponentInChildren<TMP_InputField>().text = "";
		Time.timeScale = 1;
	}
	/// <summary>
	/// Function checking if inputed password is valid, if its valid door is openedm otherwise error message will be displayed
	/// </summary>
	public void ValidatePassword()
    {
		WrongCodeMessage.SetActive(false);

        if(Door == null) return;

        if(GetComponentInChildren<TMP_InputField>().text.Length == 4 && GetComponentInChildren<TMP_InputField>().text == Door.Password)
        {
			Debug.Log("Door opened");
            Door.Open();
        }else if(GetComponentInChildren<TMP_InputField>().text.Length == 4)
		{
			GetComponentInChildren<TMP_InputField>().text = "";
			WrongCodeMessage.SetActive(true);
		}
    }

	/// <summary>
	/// Activating input field (setting focus on it)
	/// </summary>
	public void ActivateInput()
	{
		GetComponentInChildren<TMP_InputField>().ActivateInputField();
	}
}
