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
    /// Health of player
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
			HealthBar.value = 100 - health;
			HealthText.text = health.ToString();
		}
    }
    private int shield;
    /// <summary>
    /// Shield of player
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
        Shield = 50;
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
