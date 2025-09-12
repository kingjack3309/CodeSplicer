using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManagerScript : MonoBehaviour
{

    Slider healthSlider;

    public float maxHealth;
    private float currentHealth = 100;


    // Start is called before the first frame update
    void Start()
    {
        healthSlider = GetComponent<Slider>();
        healthSlider.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {        
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void LoseHealth(float damage)
    {
        currentHealth -= damage;
        healthSlider.value = currentHealth;
    }

    public void GainHealth(float heal)
    {
        currentHealth += heal;
        healthSlider.value = currentHealth;
    }
}
