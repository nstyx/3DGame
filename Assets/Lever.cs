using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("LeverUp", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenLever()
    {
        anim.SetBool("LeverUp", true);
    }
}
