using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Player reset;
    public GameObject teaCanvas;
    public GameObject teaCanvas2;
    public GameObject effect;
    int tea = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        useitem();
    }

    private void useitem()
    {
        if (Input.GetKeyDown(KeyCode.Q) && tea >= 2) 
        {
            reset.Save();
            teaCanvas2.SetActive(false);
            effect.SetActive(true);
            Invoke("cancle", 2);
            tea--;
        }
        else if (Input.GetKeyDown(KeyCode.Q) && tea >= 1)
        {
            reset.Save();
            teaCanvas.SetActive(false);
            effect.SetActive(true);
            Invoke("cancle", 2);
            tea--;
        }
    }

    void cancle()
    {
        effect.SetActive(false);
    }
    public void buytea()
    {
        tea += 1;
    }


}
