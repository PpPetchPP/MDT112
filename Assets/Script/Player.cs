using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Transform pos;

    [SerializeField] float speed = 5f;
    [SerializeField] float Jump_c = 1;
    [SerializeField] float Jump_f = 5;
    [SerializeField] float Rush = 6;
    [SerializeField] float C_Heart = 4;
    [SerializeField] float Max_Heart = 4;

    public Animator animator;
    public Camera cam;
    public heart Cheart;
    public GameObject FlashLight;

    private float m_currentV = 0;
    private float m_currentH = 0;
    private Vector3 m_currentDirection = Vector3.zero;
    public Rigidbody rigi;

    bool run = false;
    bool shoot = false;
    bool on = true;

    public GameObject player;
    Vector3 playerPosition;

    void Start()
    {
        playerPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        move();
        Anima();
    }

    private void Anima()
    {
        animator.SetBool("Run", run);
        animator.SetBool("shoot", shoot);
    }

    /*private void camm()
    {
        cam.transform.eulerAngles = new Vector3(15, 0, 0);
        cam.transform.position = new Vector3(this.transform.position.x + 0.5f, this.transform.position.y + 2f, this.transform.position.z - 2f);
    }*/


    private void move()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        Transform camera = Camera.main.transform;

        m_currentV = Mathf.Lerp(m_currentV, v, Time.deltaTime * 10);
        m_currentH = Mathf.Lerp(m_currentH, h, Time.deltaTime * 10);

        Vector3 direction = camera.forward * m_currentV + camera.right * m_currentH;

        float directionLength = direction.magnitude;
        direction.y = 0;
        direction = direction.normalized * directionLength;

        if (direction != Vector3.zero)
        {
            m_currentDirection = Vector3.Slerp(m_currentDirection, direction, Time.deltaTime * 10);

            transform.rotation = Quaternion.LookRotation(m_currentDirection);
            transform.position += m_currentDirection * speed * Time.deltaTime;
        }
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            run = true;
        }
        else
        {
            run = false;
        }



        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = Rush;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 4;
        }



        if (Input.GetKeyDown(KeyCode.Space) && Jump_c >= 1)
        {
            rigi.AddForce(Vector3.up * Jump_f, ForceMode.Impulse);
            Jump_c -= 1;
        }

        if (Input.GetMouseButton(0))
        {
            shoot = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            shoot = false;
        }


        if (Input.GetMouseButton(1))
        {
            speed = 0f;
            run = false;
        }
        if (Input.GetMouseButtonUp(1))
        {
            speed = 4;
        }

        if (C_Heart <= 0)
        {
            SceneManager.LoadSceneAsync(3);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (on == true)
            {
                FlashLight.SetActive(true);
                print("ss" + on);
                on = false;
            }
            else if (on == false)
            {
                FlashLight.SetActive(false);
                print("ss" + on);
                on = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Map")
        {
            print("Map");
            Jump_c = 1;
        }
        if (collision.gameObject.tag == "Monster")
        {
            C_Heart -= 1;
            Cheart.Cout(C_Heart);
            player.transform.position = playerPosition;
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "SaveSpawn")
        {
            playerPosition = player.transform.position;
            print("save");
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Monster2")
        {
            C_Heart -= 1;
            Cheart.Cout(C_Heart);
        }
        if (collider.gameObject.tag == "Escape")
        {
            SceneManager.LoadScene(4);
        }
    }

    public void UpgradeH()
    {
        Max_Heart = 5;
    }

    public void Save()
    {
        C_Heart = Max_Heart;
        Cheart.Cout(C_Heart);
        Cheart.reset();
    }
}
