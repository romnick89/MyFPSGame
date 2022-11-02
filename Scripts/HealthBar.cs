using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*Health Bar Script*/
public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public RawImage healthBar;

    //set player health and slider health value
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        healthBar.color = gradient.Evaluate(1f);
    }
    //set player health function
    public void SetHealth(int health)
    {
        slider.value = health;

        healthBar.color = gradient.Evaluate(slider.normalizedValue);
    }
}
