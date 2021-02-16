using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBoss : MonoBehaviour
{
    bool sw = false;
    [SerializeField] float Health = 30f;
    public Animator animator;
    public GameObject player;
    public float speed = 1f;
    public Monster3 Attack;
    public GameObject effect;

    public GameObject mon1;
    public GameObject mon2;
    public GameObject mon3;
    public GameObject wall;
    public Monster_noob monnoob1;
    public Monster_noob monnoob2;
    public Monster_noob monnoob3;

    public GameObject teasur;

    bool walk = false;
    bool run = false;
    bool death = false;
    bool sw2 = true;
    bool skill = false;
    float cf = 0f;

    void Start()
    {
        effect.gameObject.SetActive(false);
        mon1.SetActive(false);
        mon2.SetActive(false);
        mon3.SetActive(false);
        wall.SetActive(false);
        teasur.SetActive(false);
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
            wall.SetActive(true);
            teasur.SetActive(true);
            monnoob1.death();
            monnoob2.death();
            monnoob3.death();
        }


    }

    private void wave()
    {
        mon1.SetActive(true);
        mon2.SetActive(true);
        mon3.SetActive(true);
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
            if (sw2 == false && cf % 5 == 1)
            {
                animator.SetBool("Skill", skill);
            }
        }
    }
}
