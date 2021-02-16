using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shop;
    bool sw = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E) && sw == true)
        {
            shop.SetActive(true);
            sw = false;
        }
        else if (collider.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E) && sw == false)
        {
            shop.SetActive(false);
            sw = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            shop.SetActive(false);
        }
    }
}
