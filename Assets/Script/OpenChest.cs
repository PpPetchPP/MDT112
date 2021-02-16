using UnityEngine;
using System.Collections;
using System;

public class OpenChest : MonoBehaviour {

    [Range(0.0f, 1.0f)]
    public float factor;
    float Ckey = 0;

    Quaternion closedAngle;
    Quaternion openedAngle;

    public bool closing;
    public bool opening;

    public GameObject Event;
    public GameObject Key_Con;
    public GameObject Error_Key;
    public GameObject Emeral;

    public Emmeral Em;

    public float speed = 0.5f;
    bool pressE = true;

    int newAngle = 127;

    // Use this for initialization
    void Start()
    {
        Emeral.SetActive(false);
        Event.SetActive(false);
        Error_Key.SetActive(false);
        openedAngle = transform.rotation;
        closedAngle = Quaternion.Euler(transform.eulerAngles + Vector3.right * newAngle);
    }

    // Update is called once per frame
    void Update() {

        if (closing)
        {
            factor += speed * Time.deltaTime;

            if (factor > 1.0f)
            {
                factor = 1.0f;
            }
        }
        if (opening)
        {
            factor -= speed * Time.deltaTime;

            if (factor < 0.0f)
            {
                factor = 0.0f;
            }
        }

        transform.rotation = Quaternion.Lerp(openedAngle, closedAngle, factor);
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (pressE == true)
            {
                if (Input.GetKeyDown(KeyCode.E) && Ckey >= 1)
                {
                    Open();
                    Invoke("Delay", 1);
                    Em.getEmm();
                    pressE = false;
                }
                else if (Input.GetKeyDown(KeyCode.E) && Ckey < 1)
                {
                    print("Ckey = " + Ckey);
                    Error();
                }
            }
        }
    }
    public void GetKey()
    {
        Ckey += 1;
        print("Ckey = " + Ckey);
    }

    private void Error()
    {
        Error_Key.SetActive(true);
        Invoke("cancel", 1);
    }

    private void Delay()
    {
        Emeral.SetActive(true);
        Event.SetActive(true);
        Key_Con.SetActive(false);
        Invoke("cancel", 1);
    }

    private void cancel()
    {
        print("asdad");
        Event.SetActive(false);
        Error_Key.SetActive(false);
    }

    void Close()
    {
        closing = true;
        opening = false;
    }

    void Open()
    {
        opening = true;
        closing = false;
    }
}
