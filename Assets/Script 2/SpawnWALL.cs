using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWALL : MonoBehaviour
{
    public GameObject wall;
    public GameObject Audio;
    public GameObject Audio2;
    public GameObject text;
    public GameObject text2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            wall.SetActive(true);
            text.SetActive(true);
            text2.SetActive(true);
            Audio.SetActive(false);
            Audio2.SetActive(true);
            Invoke("cancle", 3);
        }
    }

    void cancle()
    {
        text2.SetActive(false);
    }
}
