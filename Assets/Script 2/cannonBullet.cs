using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonBullet : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    public Rigidbody rigidbody;
    public GameObject bomb;
    float time = 0;

    void Start()
    {
        bomb.SetActive(false);
        rigidbody.GetComponent <Rigidbody>();
        rigidbody.AddForce(transform.forward*speed);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Map")
        {
            bomb.SetActive(true);
            Destroy(gameObject,1f);
        }
    }
}
