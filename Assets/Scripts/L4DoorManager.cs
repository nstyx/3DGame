using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L4DoorManager : MonoBehaviour
{

    public GameObject Door2Open;
    public GameObject Door2Closed;
    public GameObject Door3Open;
    public GameObject Door3Closed;
    public GameObject Door4Open;
    public GameObject Door4Closed;

    //ch2 condition
    public static int ch2Win;
    //ch3 condition
    public static int ch3Win;
    //ch4 condition
    public static int ch4Win;

    // Start is called before the first frame update
    void Start()
    {
        Door2Open.SetActive(true);
        Door2Closed.SetActive(false);
        Door3Open.SetActive(false);
        Door4Open.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {

        if(ch2Win == 1) //open to ch3
        {
            Door3Open.SetActive(true);
            Door3Closed.SetActive(false);
        }
        if(ch3Win == 1) //open to ch4
        {
            Door4Open.SetActive(true);
            Door4Closed.SetActive(false);
        }
        if(ch4Win == 1) //open BOSS Chest
        {

        }
        
    }
}
