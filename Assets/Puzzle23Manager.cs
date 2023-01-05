using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle23Manager : MonoBehaviour
{

    public GameObject presPlate1;
    public GameObject presPlate2;
    public GameObject presPlate3;

    public GameObject DoorClosed;
    public GameObject DoorOpen;

    private bool p1Activated = false;
    private bool p2Activated = false;
    private bool p3Activated = false;
    private bool puzzleSolved = false;
    //order for solving is p2-p3-p1



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
            DoorClosed.gameObject.SetActive(true);
            DoorOpen.gameObject.SetActive(false);
        }
        else if(puzzleSolved)
        {
            DoorClosed.gameObject.SetActive(false);
            DoorOpen.gameObject.SetActive(true);
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
/*
------

    void Update()
    {
        // check if pressure plate 2 has been activated
        if (pressurePlate2.GetComponent<PressurePlate>().activated && !p2Activated)
        {
            p2Activated = true;
            StartCoroutine(CheckForPlate3());
        }
    }

    IEnumerator CheckForPlate3()
    {
        yield return new WaitForSeconds(3.0f); // wait for 3 seconds

        // check if pressure plate 3 has been activated within 3 seconds
        if (pressurePlate3.GetComponent<PressurePlate>().activated)
        {
            p3Activated = true;
            StartCoroutine(CheckForPlate1());
        }
        else
        {
            // reset the puzzle if pressure plate 3 was not activated within 3 seconds
            p2Activated = false;
            p3Activated = false;
        }
    }

    IEnumerator CheckForPlate1()
    {
        yield return new WaitForSeconds(3.0f); // wait for 3 seconds

        // check if pressure plate 1 has been activated within 3 seconds
        if (pressurePlate1.GetComponent<PressurePlate>().activated)
        {
            p1Activated = true;
            puzzleSolved = true;
            Debug.Log("Puzzle solved!");
        }
        else
        {
            // reset the puzzle if pressure plate 1 was not activated within 3 seconds
            p2Activated = false;
            p3Activated = false;
            p1Activated = false;
        }
    }

*/