using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int currentGold;
    public int spellAmmo;
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI spellAmmoText;
    public int currentWeapon; // 0 sword, 1 bow
    public GameObject[] weapons;
    public bool foundBook = false; //set player weapon to only sword

    // Start is called before the first frame update
    void Start()
    {
        // changeWeapon(0);
    }

    //Done: remove bow, player will be able to cast spell from standard anim once "book" is found, change bow for book
    //TO-DO: REMOVE CHANGE WEAPON MECHANIC -> player has sword, when he finds book he gains access to use the spellcast, when pressing "Key"
    // he casts spell from the standard idle animation, no need to remove sword from model
    
    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.Alpha1) && foundBook) { //once book is found
        changeWeapon(1);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha0)) {
        changeWeapon(0);
        }*/
    }

    public void addGold(int goldCollected)
    {
        currentGold += goldCollected;
        goldText.text = "Gold: " + currentGold;
    }

    public void addBook() //found bow upgrade, enable book and switch weapon mechanics
    {
        foundBook = true;
    }

    public void addSpellAmmo(int spellNum)
    {
        spellAmmo += spellNum;
        spellAmmoText.text = "" + spellAmmo;
    }
    /*
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
    }*/
}
