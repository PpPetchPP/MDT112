using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart : MonoBehaviour
{
    public GameObject heart_1;
    public GameObject heart_2;
    public GameObject heart_3;
    public GameObject heart_4;
    public GameObject heart_up;
    bool up = false;

    void Start()
    {
        heart_1.SetActive(true);
        heart_2.SetActive(true);
        heart_3.SetActive(true);
        heart_4.SetActive(true);
        heart_up.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void upgrade()
    {
        up = true;
    }
    public void reset()
    {
        heart_1.SetActive(true);
        heart_2.SetActive(true);
        heart_3.SetActive(true);
        heart_4.SetActive(true);
        if (up == true)
        {
            heart_up.SetActive(true);
        }
    }

    public void Cout(float CoutHeart)
    {
        if (up == false)
        {
            if (CoutHeart <= 3)
            {
                heart_4.SetActive(false);
            }
            if (CoutHeart <= 2)
            {
                heart_3.SetActive(false);
            }
            if (CoutHeart <= 1)
            {
                heart_2.SetActive(false);
            }
            if (CoutHeart <= 0)
            {
                heart_1.SetActive(false);
            }
        }
        else if (up == true)
        {
            if (CoutHeart <= 4)
            {
                heart_up.SetActive(false);
            }
            if (CoutHeart <= 3)
            {
                heart_4.SetActive(false);
            }
            if (CoutHeart <= 2)
            {
                heart_3.SetActive(false);
            }
            if (CoutHeart <= 1)
            {
                heart_2.SetActive(false);
            }
            if (CoutHeart <= 0)
            {
                heart_1.SetActive(false);
            }
        }
    }
}
