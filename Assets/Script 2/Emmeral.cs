using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emmeral : MonoBehaviour
{
    public Transform pos;
    public GameObject obj;
    public GameObject Emerral;
    public GameObject Runewarp;
    public Rune rn;
    public int Em = 0;
    // Start is called before the first frame update
    void Start()
    {
        Runewarp.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void getEmm()
    {
        Em += 1;
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E) && Em>=1 )
            {
                Instantiate(obj, pos.position, pos.rotation);
                rn.Get();
                Emerral.SetActive(false);
                Runewarp.SetActive(true);
                Em -= 1;
            }
        }
    }
}
