using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Ammo : MonoBehaviour
{
    [SerializeField] float life_time = 3f;
    [SerializeField] float speed = 5f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        process();
    }

    private void process()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        life_time -= Time.deltaTime;
        if (life_time <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Map")
        {
            print("Fire_Map");
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Monster")
        {
            print("Fire_Monster");
            Destroy(gameObject);
        }

    }
    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "SaveSpawn")
        {
            print("Fire_SaveSpawn");
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "SaveSpawn")
        {
            print("Fire_SaveSpawn");
            Destroy(gameObject);
        }
    }
}
