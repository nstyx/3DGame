using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    [SerializeField] float currentHealth, maxHealth = 10f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damaged(float dmgAmount)
    {
        currentHealth -= dmgAmount;

        if(currentHealth < 1)
        {
            Destroy(gameObject);
        }
    }
}
