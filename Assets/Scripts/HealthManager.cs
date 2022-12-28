using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public TextMeshProUGUI healthText;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthText.text = "Health: " + currentHealth; // initial load
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playerDamage(int dmg)
    {
        currentHealth -= dmg;
        healthText.text = "Health: " + currentHealth;

        if(currentHealth < 1)
        {
            //implement death
        }
    }

    // implement heal pickups, or heal over time?
    public void playerHeal(int heal)
    {
        if(maxHealth > currentHealth + heal) // 50hp + 20hp heal = 70hp
        {
            currentHealth += heal;
            healthText.text = "Health: " + currentHealth;
        }
        else if(maxHealth <= currentHealth + heal) // 90hp + 20hp heal = 100hp
        {
            currentHealth = maxHealth;
            healthText.text = "Health: " + currentHealth;
        }
    }
}
