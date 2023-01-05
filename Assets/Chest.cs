using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private float currentHealth;
    private float maxHealth = 2;
    //private bool chestOpen;

    [SerializeField] public GameObject[] reward;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        //chestOpen = false;

        reward[0].gameObject.SetActive(false);
        reward[1].gameObject.SetActive(false);
        reward[2].gameObject.SetActive(false);
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
            //chestOpen = true;
            ShowReward();
            Debug.Log("Chest open");
            Destroy(gameObject);
        }
    }
    public void ShowReward()
    {
        reward[0].gameObject.SetActive(true);
        reward[1].gameObject.SetActive(true);
        reward[2].gameObject.SetActive(true);
    }
}
