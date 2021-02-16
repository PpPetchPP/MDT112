using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject key_canvas;
    public GameObject pos_gate;
    public GameObject gate;
    public OpenChest box;

    public float speed = 50f;
    // Start is called before the first frame update
    void Start()
    {
        key_canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Instantiate(gate, pos_gate.transform.position, pos_gate.transform.rotation);
            key_canvas.SetActive(true);
            box.GetKey();
            Destroy(gameObject);
        }
    }
}
