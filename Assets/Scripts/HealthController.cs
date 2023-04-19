using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//Health controller, setting HP and updating UI bar
public class HealthController : MonoBehaviour
{
    private int health;
    /// <summary>
    /// Health of player, on set it is checking if health is not below 0 or over 100 and updating GUI health bar
    /// </summary>
    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
			if (health <= 0)
			{
				if (!dying)
				{
					dying = true;
					FindObjectOfType<GameManager>().GoToNextScene(0);
				}
				health = 0;
			}
			else if (health > 100)
				health = 100;
            //updates health bar
			HealthBar.value = 100 - health;
			HealthText.text = health.ToString();
		}
    }
    private int shield;
	/// <summary>
	/// Shield of player, on set it is checking if shield is not below 0 or over 100 and updating GUI shield bar
	/// </summary>
	public int Shield
    {
        get
        {
            return shield;
        }
        set
        {
            shield = value;
			if (shield > 100)
				shield = 100;
			else if (shield < 0)
				shield = 0;
            
            if(shield == 0)
                ShieldBar.enabled= false;
            else ShieldBar.enabled= true;

			ShieldBar.value = 100 - shield;
            ShieldText.text = shield.ToString();
		}
    }
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
        Shield = 0;
    }
    /// <summary>
    /// Check if player is dying
    /// </summary>
    private bool dying = false;

    /// <summary>
    /// Taking damage by player, if player has shield on, first damage will go through it, then it will lower his health
    /// </summary>
    /// <param name="damage">Amount of damage taken</param>
    public void TakeDamage(int damage)
    {
        if(Shield > 0)
        {
            if(Shield - damage < 0)
            {
                Health += (Shield - damage);
                Shield = 0;
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
