using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle23Manager : MonoBehaviour
{

    public GameObject presPlate1;
    public GameObject presPlate2;
    public GameObject presPlate3;

    public GameObject l3DoorClosed;
    public GameObject l3DoorOpen;
    public GameObject JDoorClosed;
    public GameObject JDoorOpen;

    private bool p1Activated = false;
    private bool p2Activated = false;
    private bool p3Activated = false;
    private bool puzzleSolved = false;
    //order for solving is p2-p3-p1

    void Start()
    {
        JDoorOpen.gameObject.SetActive(false);
        l3DoorOpen.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(presPlate2.GetComponent<Pressure23>().plateActivated && !p2Activated)
        {
            p2Activated = true;
            StartCoroutine(CheckPlate3());
        }
        if(!puzzleSolved)
        {
            JDoorClosed.gameObject.SetActive(true);
            JDoorOpen.gameObject.SetActive(false);
        }
        else if(puzzleSolved)
        {
            JDoorClosed.gameObject.SetActive(false);
            JDoorOpen.gameObject.SetActive(true);
        }
        if(puzzleSolved && GameManager.foundKeyLvl3 == 1)
        {
            l3DoorClosed.gameObject.SetActive(false);
            l3DoorOpen.gameObject.SetActive(true);
        }
    }

    IEnumerator CheckPlate3()
    {
        yield return new WaitForSeconds(3.0f);
        
        if(presPlate3.GetComponent<Pressure23>().plateActivated)
        {
            p3Activated = true;
            StartCoroutine(CheckPlate1());
        }
        else //reset
        {
            p3Activated = false;
            p2Activated = false;
        }
    }

    IEnumerator CheckPlate1()
    {
        yield return new WaitForSeconds(3.0f);
        
        if(presPlate1.GetComponent<Pressure23>().plateActivated)
        {
            p1Activated = true;
            puzzleSolved = true;
            Debug.Log("Solved!");
        }
        else //reset
        {
            p1Activated = false;
            p2Activated = false;
            p3Activated = false;
        }
    }
}