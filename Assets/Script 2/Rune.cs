using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rune : MonoBehaviour
{
    bool sw = false;
    public Transform pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Get()
    {
        sw = true;
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E) && sw == true)
            {
                collider.transform.position = pos.transform.position;
            }
        }
    }
}
