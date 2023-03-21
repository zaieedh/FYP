using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class DoorInputLocker : MonoBehaviour
{
    public Door Door;
	public GameObject WrongCodeMessage;

	public void Close()
	{
		GetComponentInChildren<TMP_InputField>().text = "";
		Time.timeScale = 1;
	}

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

	public void ActivateInput()
	{
		GetComponentInChildren<TMP_InputField>().ActivateInputField();
	}
}
