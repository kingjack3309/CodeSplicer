using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManagerScript : MonoBehaviour
{

    Slider healthSlider;

    public int maxHealth = 100;
    private int currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        healthSlider = GetComponent<Slider>();
        healthSlider.value = currentHealth;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {        
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        healthSlider.value = currentHealth;
    }

    public void LoseHealth(int damage)
    {
        currentHealth -= damage;
    }

    public void GainHealth(int heal)
    {
        currentHealth += heal; 
    }
}
