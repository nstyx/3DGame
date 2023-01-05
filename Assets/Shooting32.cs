using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting32 : MonoBehaviour
{
    
    public GameObject bannerTarget;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ch2Win: " + L4DoorManager.ch2Win);
    }

    // Update is called once per frame
    void Update()
    {

        if(bannerTarget.GetComponent<BannerTarget>().haveBeenHit)
        {
            L4DoorManager.ch2Win = 1;
        }
    }
}
