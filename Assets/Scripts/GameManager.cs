using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int currentGold;
    public TextMeshProUGUI goldText;
    public GameObject[] MagicBallUIBars; // 0 = ON, 1 = OFF
    static public bool foundBook = false; //set player weapon to only sword
    // bool weaponSword = true;
    // bool weaponMagicSpell = false;

    public PlayerAttack PA;

    // Start is called before the first frame update
    void Start()
    {
        goldText.text = "Gold: " + currentGold; //update UI gold on each scene init
    }

    //Done: remove bow, player will be able to cast spell from standard anim once "book" is found, change bow for book
    //TO-DO: REMOVE CHANGE WEAPON MECHANIC -> player has sword, when he finds book he gains access to use the spellcast, when pressing "Key"
    // he casts spell from the standard idle animation, no need to remove sword from model
    
    // Update is called once per frame
    void Update()
    {
        if(PA.spellAmmo < 1)
        {
            MagicBallUIBars[1].gameObject.SetActive(true); //if no ammo deactivate spellUI
            MagicBallUIBars[0].gameObject.SetActive(false);
        }
    }

    public void addGold(int goldCollected)
    {
        //currentGold += goldCollected;
        goldText.text = "Gold: " + currentGold;
    }

    public void addBook() //found book upgrade, enable book and add
    {
        MagicBallUIBars[1].gameObject.SetActive(false);
        MagicBallUIBars[0].gameObject.SetActive(true);//activate spell UI

        if(!foundBook)
        {
            PA.foundBook = true;
            //weaponMagicSpell = true;
        }

        PA.spellAmmo += 10;
        PA.updateAmmo();
    }
}
