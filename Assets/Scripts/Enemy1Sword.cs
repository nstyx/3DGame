using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Sword : MonoBehaviour
{
    public int enemyDamage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<HealthManager>().playerDamage(enemyDamage);
        }
    }
}
