using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cut : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("des", 2);
    }

    void des()
    {
        Destroy(gameObject);
    }
}
