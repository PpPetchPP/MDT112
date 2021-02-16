using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBoss3 : MonoBehaviour
{
    bool sw = false;
    [SerializeField] float Health = 40f;
    public Animator animator;
    public GameObject player;
    public float speed = 1f;
    public Monster3 Attack;
    public GameObject effect;
    public GameObject spawnee;
    public Transform spawnpos;
    public Transform spawnpos1;
    public Transform spawnpos2;
    public GameObject skillboss;
    public GameObject key;

    bool walk = false;
    bool run = false;
    bool death = false;
    bool sw2 = true;
    bool skill = false;
    bool bullet = false;
    float cf = 0f;
    Vector3 bosspos;

    void Start()
    {
        effect.gameObject.SetActive(false);
        bosspos = this.transform.position;
        key.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (sw == true)
        {
            MoveRotate(this.transform.position.x, this.transform.position.z, player.transform.position.x, player.transform.position.z);
        }
        MovePosition();
        Skill();
    }

    public void fate()
    {
        if (sw2 = true)
        {
            speed = 1;
        }
        else if (sw2 = false)
        {
            speed = 7;
        }
        bullet = false;
    }
    public void fateoff()
    {
        speed = 0;
        bullet = true;
        this.transform.position = bosspos;
    }

    private void Skill()
    {
        if (Health <= 10 && sw2 == true)
        {
            walk = false;
            run = true;
            sw2 = false;
            skill = true;
            animator.SetBool("Skill", skill);
            speed = 7f;
            effect.gameObject.SetActive(true);
            skillboss.SetActive(true);

        }
        if (Health <= 0)
        {
            walk = false;
            run = false;
            death = true;
            speed = 0;
            animator.SetBool("Death", death);
            Destroy(gameObject, 3.5f);
            Invoke("keyset", 1);
        }


    }
    void keyset()
    {
        key.SetActive(true);
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
        if (collider.gameObject.tag == "Player" && sw == false)
        {
            print("sw on");
            bullet = true;
            sw = true;
            walk = true;
            InvokeRepeating("wave", 3f, 3f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Health -= 2f;
            cf++;
        }
    }

    void wave()
    {
        if (bullet == true)
        {
            Instantiate(spawnee, spawnpos.position, spawnpos.rotation);
            Instantiate(spawnee, spawnpos1.position, spawnpos1.rotation);
            Instantiate(spawnee, spawnpos2.position, spawnpos2.rotation);
        }
    }
}
