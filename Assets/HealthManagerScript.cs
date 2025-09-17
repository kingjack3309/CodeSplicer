using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthManagerScript : MonoBehaviour
{

    Slider healthSlider;

    GameObject healthText;

    private string healthRemaining;

    public int maxHealth = 100;
    private int currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        healthSlider = GetComponent<Slider>();
        currentHealth = maxHealth;
        healthSlider.value = currentHealth;

        healthText = GameObject.Find("HealthText");
     }

    // Update is called once per frame
    void Update()
    {        
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        healthSlider.value = currentHealth;
        healthRemaining = healthSlider.value.ToString();
        healthText.GetComponent<TMP_Text>().text = healthRemaining + "/100";
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
