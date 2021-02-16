using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wtf : MonoBehaviour
{
    bool sw = false;
    public GameObject effect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Method()
    {
        if (sw == true)
        {
            while (true)
            {
                yield return new WaitForSeconds(2f);
                Instantiate(effect, new Vector3(Random.Range(-100, -125), -3.5f, Random.Range(14, 70)), Quaternion.identity);
                yield return new WaitForSeconds(0.7f);
                Instantiate(effect, new Vector3(Random.Range(-100, -125), -3.5f, Random.Range(14, 70)), Quaternion.identity);
                yield return new WaitForSeconds(0.3f);
                Instantiate(effect, new Vector3(Random.Range(-100, -125), -3.5f, Random.Range(14, 70)), Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
                Instantiate(effect, new Vector3(Random.Range(-100, -125), -3.5f, Random.Range(14, 70)), Quaternion.identity);
                yield return new WaitForSeconds(0.6f);
                Instantiate(effect, new Vector3(Random.Range(-100, -125), -3.5f, Random.Range(14, 70)), Quaternion.identity);
            }
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player" && sw == false)
        {
            sw = true;
            StartCoroutine(Method());
        }
    }
}
