using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : MonoBehaviour
{
    [SerializeField] float life_time = 3f;
    [SerializeField] float speed = 5f;
    public GameObject player;
    bool sw = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("TT_ww1_demo_british_A");
        Invoke("process", 1);
        if (sw == true)
        {
            MoveRotate(this.transform.position.x, this.transform.position.y, this.transform.position.z, player.transform.position.x, player.transform.position.y, player.transform.position.z);
            Invoke("delay", 1);
        }
    }

    void delay()
    {
        sw = false;
    }

    void MoveRotate(float sx, float sy, float sz, float x,float y, float z)
    {
        float r2d = 57.29578f;
        float thetaZ = r2d * Mathf.Atan2(x - sx, z - sz);
        float distance = Mathf.Sqrt(Mathf.Pow(x - sx, 2) + Mathf.Pow(z - sz, 2));
        this.transform.rotation = Quaternion.Euler(90, 0, -thetaZ);
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

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {

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
}
