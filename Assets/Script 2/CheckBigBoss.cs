using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBigBoss : MonoBehaviour
{
    bool attack = false;
    public BigBosss bigBosss;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            bigBosss.fate();
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            bigBosss.fateoff();
        }
    }
}
