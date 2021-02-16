using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_Trigger : MonoBehaviour
{
    public GameObject key_canvas;
    public OpenChest box;


    // Start is called before the first frame update
    void Start()
    {
        key_canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            key_canvas.SetActive(true);
            Destroy(gameObject);
            box.GetKey();
        }
    }
}
