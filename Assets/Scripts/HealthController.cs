using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//Health controller, setting HP and updating UI bar
public class HealthController : MonoBehaviour
{
    [Range(0,100)]
    public static int Health;
    [Range(0, 100)]
    public static int Shield;
    public Slider HealthBar;
    public TextMeshProUGUI HealthText;
	public Slider ShieldBar;
	public TextMeshProUGUI ShieldText;

	private void Start()
    {
        Health = 100;
        Shield = 50;
    }

    private bool dying = false;

    private void Update()
    {
        if (FindObjectOfType<Scene_one_controller>() != null)
        {
            if (Health <= 0)
            {
                if (!dying)
                {
                    dying = true;
                    StartCoroutine(FindObjectOfType<Scene_one_controller>().GoToNextScene(0));
                }
                Health = 0;
            }
            else if (Health > 100)
                Health = 100;

            if(Shield > 100)
                Shield = 100;
            else if(Shield < 0)
                Shield = 0;

            HealthBar.value = 100 - Health;
            HealthText.text = Health.ToString();

			ShieldBar.value = 100 - Shield;
			ShieldText.text = Shield.ToString();
		}
    }

    public static void TakeDamage(int damage)
    {
        if(Shield > 0)
        {
            if(Shield - damage < 0)
            {
                Health += (Shield - damage);
            }
            else
            {
                Shield -= damage;
            }
        }
        else
        {
            Health -= damage;
        }
    }
}
