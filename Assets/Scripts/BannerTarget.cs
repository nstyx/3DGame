using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerTarget : MonoBehaviour
{
    public bool haveBeenHit;
    // Start is called before the first frame update
    void Start()
    {
        haveBeenHit = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getHit()
    {
        haveBeenHit = true;
        //color change?
        MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();

        if(meshRenderer != null)
        {
            meshRenderer.material.color = Color.green;
        }
    }
}
