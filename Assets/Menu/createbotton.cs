using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createbotton : MonoBehaviour
{
    public GameObject botton;
    public GameObject botton2;
    public GameObject Game;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("eiei", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void eiei()
    {
        botton.SetActive(true);
        botton2.SetActive(true);
        Game.SetActive(true);
    }
}
