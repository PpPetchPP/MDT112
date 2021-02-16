using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster2 : MonoBehaviour
{
    bool sw = false;
    [SerializeField] float Health = 30f;
    public Animator animator;
    public GameObject player;
    public float speed = 1f;
    public Monster3 Attack;
    public GameObject effect;

    public Transform spownPos1;
    public Transform spownPos2;
    public Transform spownPos3;
    public Transform spownPos4;
    public Transform spownPos5;
    public GameObject spawnee;

    bool walk = false;
    bool run = false;
    bool death = false;
    bool sw2 = true;
    bool skill = false;
    float cf = 0f;

    public GameObject wall;
    public GameObject save;

    void Start()
    {
        effect.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        MoveRotate(this.transform.position.x, this.transform.position.z, player.transform.position.x, player.transform.position.z);
        MovePosition();
        Skill();
    }

    public void Hit(bool attack)
    {
        animator.SetBool("Attack", attack);
    }

    private void Skill()
    {
        if (Health <= 30 && sw2 == true)
        {
            walk = false;
            run = true;
            sw2 = false;
            skill = true;
            animator.SetBool("Skill", skill);
            speed = 2f;
            effect.gameObject.SetActive(true);
            wave();

        }
        if (Health <= 0)
        {
            walk = false;
            run = false;
            death = true;
            speed = 0;
            animator.SetBool("Death", death);
            Destroy(gameObject, 3.5f);
            Destroy(wall);
            save.SetActive(true);
        }


    }

    private void wave()
    {
        Instantiate(spawnee, spownPos1.position, spownPos1.rotation);
        Instantiate(spawnee, spownPos2.position, spownPos2.rotation);
        Instantiate(spawnee, spownPos3.position, spownPos3.rotation);
        Instantiate(spawnee, spownPos4.position, spownPos4.rotation);
        Instantiate(spawnee, spownPos5.position, spownPos5.rotation);
    }

    private void MovePosition()
    {
        if (sw == true)
        {
            this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            if (sw2 == true)
            {
                animator.SetBool("Walk", walk);
            }
            animator.SetBool("Run", run);
        }
    }

    void MoveRotate(float sx, float sz, float x, float z)
    {
        float r2d = 57.29578f;
        float theta = r2d * Mathf.Atan2(x - sx, z - sz);
        this.transform.rotation = Quaternion.Euler(0, theta, 0);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            print("sw on");
            sw = true;
            walk = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Health -= 2f;
            cf++;
            if (sw2 == false && cf%5==1)
            {
                animator.SetBool("Skill", skill);
                wave();
            }
        }
    }
}
