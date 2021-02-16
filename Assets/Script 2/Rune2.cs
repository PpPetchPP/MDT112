using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rune2 : MonoBehaviour
{
    public Transform pos;
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
        if (collider.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                collider.transform.position = pos.transform.position;
            }
        }
    }
}
