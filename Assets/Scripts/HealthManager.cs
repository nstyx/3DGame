using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    static public int currentHealth;
    public TextMeshProUGUI healthText;
    public GameObject[] Swords; // 0=big, 1=med, 2=small
    public bool isInvincible = false;
    public static bool playerDied; //make global?
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        playerDied = false;
        anim.SetBool("isDead", false);
        currentHealth = maxHealth;
        healthText.text = "Health: " + currentHealth; // initial load
    }

    // Update is called once per frame
    void Update()
    {
        // sword size ranges: 70-100 Big, 40-69 Medium, 1-39 Small
        if(currentHealth > 69)
        {
            Swords[0].gameObject.SetActive(true);
            Swords[1].gameObject.SetActive(false);
            Swords[2].gameObject.SetActive(false);
        }
        if(currentHealth > 39 && currentHealth < 70)
        {
            Swords[0].gameObject.SetActive(false);
            Swords[1].gameObject.SetActive(true);
            Swords[2].gameObject.SetActive(false);
        }
        if(currentHealth > 0 && currentHealth < 40)
        {
            Swords[0].gameObject.SetActive(false);
            Swords[1].gameObject.SetActive(false);
            Swords[2].gameObject.SetActive(true);
        }


        if(Input.GetButtonDown("Invincibility"))
        {
            if(isInvincible) isInvincible = false;
            else isInvincible = true;
        }
        
    }

    public void playerDamage(int dmg)
    {
        if(!isInvincible)
        {
            currentHealth -= dmg;
            healthText.text = "Health: " + currentHealth;
        }

        if(currentHealth < 1)
        {
            playerDied = true;
            anim.SetBool("isDead", true);
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
