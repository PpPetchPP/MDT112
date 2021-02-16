using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BigBosss : MonoBehaviour
{
    [SerializeField] float speed = 1;
    public GameObject player;
    public Animator animator;
    public GameObject Katana;
    public GameObject fireball;
    public GameObject Monster;
    public GameObject text;
    public GameObject text2;
    public float Heath = 100;
    public Transform pos;
    public Transform pos1;
    public Transform pos2;
    public Transform pos3;
    public Transform pos4;
    public Transform pos5;
    public Rigidbody rigidbody;

    public GameObject effect;
    public GameObject effect2;

    bool walk = false;
    bool death;
    bool bullet = false;
    bool sw = false;
    bool sw2 = true;
    bool attack = false;
    bool sw3 = false;

    void Start()
    {
        rigidbody.GetComponent<Rigidbody>();
        InvokeRepeating("MovePosition", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        MoveRotate(this.transform.position.x, this.transform.position.z, player.transform.position.x, player.transform.position.z);
        animator.SetBool("dead", death);
        State();
    }

    private void State()
    {
        if (Heath <= 70)
        {
            sw2 = false;
            effect.SetActive(true);
        }
        if (Heath <= 30)
        {
            sw3 = true;
            effect2.SetActive(true);
        }
        if (Heath <= 0)
        {
            walk = false;
            death = true;
            text.SetActive(false);
            text2.SetActive(true);
            Destroy(gameObject,5f);
        }
    }

    void MoveRotate(float sx, float sz, float x, float z)
    {
        float r2d = 57.29578f;
        float theta = r2d * Mathf.Atan2(x - sx, z - sz);
        this.transform.rotation = Quaternion.Euler(0, theta, 0);
    }

    private void MovePosition()
    {
        if (walk == true)
        {
            rigidbody.AddForce(Vector3.forward*speed,ForceMode.Impulse);
            animator.SetBool("walk", walk);
        }
    }
    public void fate()
    {
        if (sw2 == true)
        {
            speed = 10;
            walk = true;
        }
        else if (sw2 == false)
        {
            speed = 15;
        }
        bullet = false;
    }
    public void fateoff()
    {
        speed = 0;
        bullet = true;
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player" && sw == false)
        {
            print("sw on");
            bullet = true;
            sw = true;
            InvokeRepeating("wave", 2f, 2f);
        }
        if (collider.gameObject.tag == "State2")
        {
            bullet = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Heath -= 1.5f;
        }
        if (collision.gameObject.tag == "Escape")
        {
            SceneManager.LoadSceneAsync(3);
        }
    }

    void wave()
    {
        if (sw3 == false)
        {
            if (sw2 == true)
            {
                if (bullet == true)
                {
                    Instantiate(Katana, pos1.position, pos1.rotation);

                }
                if (bullet == false)
                {
                    Instantiate(Katana, pos.position, pos.rotation);
                    Instantiate(Katana, pos1.position, pos1.rotation);
                    Instantiate(Katana, pos2.position, pos2.rotation);
                }
            }
            else if (sw2 == false)
            {
                if (bullet == true)
                {
                    Instantiate(fireball, pos4.position, pos4.rotation);

                }
                if (bullet == false)
                {
                    Instantiate(fireball, pos3.position, pos3.rotation);
                    Instantiate(fireball, pos4.position, pos4.rotation);
                    Instantiate(fireball, pos5.position, pos5.rotation);
                }
            }
        }
        else if (sw3 == true)
        {
            if (bullet == true)
            {
                Instantiate(Katana, pos1.position, pos1.rotation);
                Instantiate(fireball, pos3.position, pos3.rotation);
                Instantiate(fireball, pos5.position, pos5.rotation);
            }
            if (bullet == false)
            {
                Instantiate(fireball, pos4.position, pos4.rotation);
                Instantiate(fireball, pos3.position, pos3.rotation);
                Instantiate(fireball, pos4.position, pos4.rotation);
                Instantiate(fireball, pos5.position, pos5.rotation);
            }
        }
    }
}
