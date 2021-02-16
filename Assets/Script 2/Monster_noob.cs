using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_noob : MonoBehaviour
{
    public GameObject player;
    public Animator animator;
    public GameObject effect;

    float delay = 2;

    public Transform pos1;
    public Transform pos2;
    public Transform pos3;
    public Transform pos4;
    public Transform pos5;
    public Transform pos6;
    public Transform pos7;
    public GameObject spawnee;
    public GameObject spawnee2;

    [SerializeField] int Health = 10;
    [SerializeField] float speed = 1;

    bool walk = true;
    bool attack = false;

    void Start()
    {
        effect.SetActive(true);
        Invoke("Effect", delay);
    }

    void Effect()
    {
        effect.SetActive(false);
    }

    void Update()
    {
        MoveRotate(this.transform.position.x, this.transform.position.z, player.transform.position.x, player.transform.position.z);
        MovePosition();
        if (Health <= 0)
        {
            Destroy(gameObject);
            Instantiate(spawnee, pos1.position, pos1.rotation);
            Instantiate(spawnee, pos2.position, pos2.rotation);
            Instantiate(spawnee, pos3.position, pos3.rotation);
            Instantiate(spawnee, pos4.position, pos4.rotation);
            Instantiate(spawnee, pos5.position, pos5.rotation);
            Instantiate(spawnee, pos6.position, pos6.rotation);
            Instantiate(spawnee2, pos7.position, pos7.rotation);
        }
    }
    public void death()
    {
        Health = 0;
    }

    void MoveRotate(float sx, float sz, float x, float z)
    {
        float r2d = 57.29578f;
        float theta = r2d * Mathf.Atan2(x - sx, z - sz);
        this.transform.rotation = Quaternion.Euler(0, theta, 0);
    }

    private void MovePosition()
    {
        this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        animator.SetBool("walk", walk);
        animator.SetBool("attack", attack);
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            attack = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            attack = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Health -= 2;
        }
    }
}
