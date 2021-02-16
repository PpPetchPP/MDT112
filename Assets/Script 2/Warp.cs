using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Warp : MonoBehaviour
{
    public GameObject player;
    public GameObject pos;
    Vector3 posi;
    // Start is called before the first frame update
    void Start()
    {
        posi = pos.transform.position;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.transform.position = posi;
        }
    }
}
