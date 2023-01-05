using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting34 : MonoBehaviour
{
    
    public GameObject bannerTarget1;
    public GameObject bannerTarget2;
    public GameObject bannerTarget3;
    public GameObject bannerTarget4;

    public GameObject doorClosed;
    public GameObject doorOpen;
    
    void Start()
    {
        Debug.Log("ch4Win: " + L4DoorManager.ch3Win);
        doorClosed.SetActive(true);
        doorOpen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if(bannerTarget1.GetComponent<BannerTarget>().haveBeenHit 
        && bannerTarget2.GetComponent<BannerTarget>().haveBeenHit
        && bannerTarget3.GetComponent<BannerTarget>().haveBeenHit
        && bannerTarget4.GetComponent<BannerTarget>().haveBeenHit)
        {
            L4DoorManager.ch4Win = 1;
            doorClosed.SetActive(false);
            doorOpen.SetActive(true);
        }
    }
}
