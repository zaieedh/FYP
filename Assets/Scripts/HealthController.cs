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
    public Slider HealthBar;
    public TextMeshProUGUI HealthText;

    private void Start()
    {
        Health = 100;
    }

    private void Update()
    {
        if (Health <= 0)
            Health = 0;
        HealthBar.value = 100 - Health;
        HealthText.text = Health.ToString();
    }
}
