using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentGold;
    public int currentWeapon; // 0 sword, 1 bow
    public GameObject[] weapons;
    bool foundBow = false; //set player weapon to only sword

    // Start is called before the first frame update
    void Start()
    {
        changeWeapon(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) && foundBow) { //once bow is found
        changeWeapon(1);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha0)) {
        changeWeapon(0);
        }
    }

    public void addGold(int goldCollected)
    {
        currentGold += goldCollected;
    }

    public void addBow() //found bow upgrade, enable bow and switch weapon mechanics
    {
        foundBow = true;
    }

    public void changeWeapon(int num)
    {
        currentWeapon = num;
        for (int i = 0; i < weapons.Length; i++)
        {
            if(i == num) //weapon selected
            {
                weapons[i].gameObject.SetActive(true);
            }
            else //other weapon deactivated
            {
                weapons[i].gameObject.SetActive(false);
            }
        }
    }
}
