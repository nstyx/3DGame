using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting33 : MonoBehaviour
{
    
    public GameObject bannerTarget1;
    public GameObject bannerTarget2;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ch3Win: " + L4DoorManager.ch3Win);
    }

    // Update is called once per frame
    void Update()
    {

        if(bannerTarget1.GetComponent<BannerTarget>().haveBeenHit && bannerTarget2.GetComponent<BannerTarget>().haveBeenHit)
        {
            L4DoorManager.ch3Win = 1;
        }
    }
}
