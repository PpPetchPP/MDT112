using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    public GameObject effect;
    public Player ply;
    public Shoot shoot;

    bool sw = false;
    // Start is called before the first frame update
    void Start()
    {
        effect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E) && sw == false)
            {
                effect.SetActive(true);
                ply.Save();
                shoot.reset();
                sw = true;
            }
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Invoke("effectshow", 3);     
        }
    }
    void effectshow()
    {
        effect.SetActive(false);
    }
}
