using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testcannon : MonoBehaviour
{
    public Transform pos;
    public GameObject obj;
    public GameObject player;
    [SerializeField] float delay = 1;

    bool attack = false;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", delay, delay);
    }

    // Update is called once per frame
    void Update()
    {
        MoveRotate(this.transform.position.x,this.transform.position.y, this.transform.position.z, player.transform.position.x, player.transform.position.y, player.transform.position.z);
    }

    private void Shoot()
    {
        if (attack == true)
        {
            Instantiate(obj, pos.position, pos.rotation);
        }
    }

    void MoveRotate(float sx,float sy, float sz, float x,float y, float z)
    {
        float r2d = 57.29578f;
        float theta = r2d * Mathf.Atan2(x - sx, z - sz);

        float distanceX = Mathf.Sqrt(Mathf.Pow(x - sx, 2) + Mathf.Pow(z - sz, 2));
        float distanceY = Mathf.Sqrt(Mathf.Pow(y - sy, 2));
        float tan = -(180/3.14159f)*(2-Mathf.Atan(distanceX/10));

        if (tan <= -45)
        {
            tan -= 2;
        }
        if (attack == true)
        {
            this.transform.rotation = Quaternion.Euler(tan, theta, 0);
        }
        
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            attack = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            attack = false;
        }
    }
}
