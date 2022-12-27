using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsScript : MonoBehaviour
{
    // TO-DO add bool that sets current weapon, to prevent shoot animation in sword mode, and melee animation in bow mode
    public int currentWeapon; // 0 sword, 1 bow
    public GameObject[] weapons;
    // Start is called before the first frame update
    void Start()
    {
        changeWeapon(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) {
        changeWeapon(1);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha0)) {
        changeWeapon(0);
        }
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
