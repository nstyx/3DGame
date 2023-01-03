using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitboxControl : MonoBehaviour
{
    public Transform joinItemSwords;
    //BoxCollider colliderSword;
    private GameObject sw1, sw2, sw3;
    [SerializeField] BoxCollider swordBig, swordMedium, swordSmall;

    // Start is called before the first frame update
    void Start()
    {
        sw1 = joinItemSwords.GetChild(0).gameObject;
        sw2 = joinItemSwords.GetChild(1).gameObject;
        sw3 = joinItemSwords.GetChild(2).gameObject;

        if(!sw1.activeSelf) swordBig.enabled = false;
        if(sw2.activeSelf) swordMedium.enabled = false;
        if(sw3.activeSelf) swordSmall.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(sw1.activeSelf) swordBig.enabled = false;
        if(sw2.activeSelf) swordMedium.enabled = false;
        if(sw3.activeSelf) swordSmall.enabled = false;
    }
    public void AttackStart()
    {
        if(sw1.activeSelf) //bigsword
        {
            swordBig.enabled = true;
        }
        else if(sw2.activeSelf) //mediumsword
        {
            swordMedium.enabled = true;
        }
        else if(sw3.activeSelf) //smallsword
        {
            swordSmall.enabled = true;
        }
    }

    public void AttackFinish()
    {
        if(sw1.activeSelf) //bigsword
        {
            swordBig.enabled = false;
        }
        else if(sw2.activeSelf) //mediumsword
        {
            swordMedium.enabled = false;
        }
        else if(sw3.activeSelf) //smallsword
        {
            swordSmall.enabled = false;
        }
    }
}
