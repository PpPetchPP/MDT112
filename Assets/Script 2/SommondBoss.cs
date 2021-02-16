using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SommondBoss : MonoBehaviour
{
    public GameObject boss;
    bool sw = true;
    // Start is called before the first frame update
    void Start()
    {
        boss.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player" && sw == true)
        {
            boss.SetActive(true);
            sw = false;
        }
    }
}
