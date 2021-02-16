using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster1 : MonoBehaviour
{
    bool sw = false;
    [SerializeField] float Health = 20f;
    public GameObject player;
    public float speed = 1f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveRotate(this.transform.position.x, this.transform.position.z, player.transform.position.x, player.transform.position.z);
        MovePosition();
    }

    private void MovePosition()
    {
        if (sw == true)
        {
            this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void MoveRotate(float sx, float sz, float x, float z)
    {
        float r2d = 57.29578f;
        float theta = r2d * Mathf.Atan2(x - sx, z - sz);
        this.transform.rotation = Quaternion.Euler(0, theta, 0);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            print("sw on");
            sw = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Health -= 2f;
        }
    }
}
