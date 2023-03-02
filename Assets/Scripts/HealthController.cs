using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//Health controller, setting HP and updating UI bar
public class HealthController : MonoBehaviour
{
    /// <summary>
    /// Health of player
    /// </summary>
    [Range(0,100)]
    public static int Health;
    /// <summary>
    /// Shield of player
    /// </summary>
    [Range(0, 100)]
    public static int Shield;
    /// <summary>
    /// UI Health bar
    /// </summary>
    public Slider HealthBar;
    /// <summary>
    /// UI text of health bar
    /// </summary>
    public TextMeshProUGUI HealthText;
    /// <summary>
    /// UI shield bar
    /// </summary>
	public Slider ShieldBar;
    /// <summary>
    /// Ui text of shield bar
    /// </summary>
	public TextMeshProUGUI ShieldText;

	private void Start()
    {
        //Setting up health and shield at the beggining of the game
        Health = 100;
        Shield = 50;
    }
    /// <summary>
    /// Check if player is dying
    /// </summary>
    private bool dying = false;

    private void Update()
    {
        //Updating health and shield UI based on their values, if health goes below 0, GAME RESTARTS
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
    /// <summary>
    /// Taking damage by player, if player has shield on, first damage will go through it, then it will lower his health
    /// </summary>
    /// <param name="damage">Amount of damage taken</param>
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
