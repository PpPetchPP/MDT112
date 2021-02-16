using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;

    public Animator animator;
    public Transform spownPos;
    public Transform spownPos1;
    public Transform spownPos2;
    public GameObject spawnee;
    public Text Ammo_text;
    bool sw = true;
    bool up = false;
    [SerializeField] int ammo = 0;
    int max_ammo = 100;


    void Start()
    {
        audioSource.clip = audioClip;
    }

    // Update is called once per frame
    void Update()
    {
        if (ammo >= 1)
        {
            if (sw == true)
            {
                if (Input.GetMouseButton(0))
                {
                    Instantiate(spawnee, spownPos.position, spownPos.rotation);
                    if (up == true && ammo % 3 ==0)
                    {
                        audioSource.Play();
                        Instantiate(spawnee, spownPos1.position, spownPos1.rotation);
                        Instantiate(spawnee, spownPos2.position, spownPos2.rotation);
                        ammo -= 2;
                    }
                    ammo--;
                    sw = false;
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                sw = true;
            }
        }
        Ammo_text.text = "Ammo : " + ammo;
    }

    public void upgrade()
    {
        max_ammo = 150;
        print("Max = " + max_ammo);
    }

    public void upgrade2()
    {
        up = true;
    }

    public void reset()
    {
        ammo = max_ammo;
        print("ammo = " + ammo);
    }

    private void OnTriggerEnter(Collider collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ammo":
                print("Ammo");
                ammo++;
                break;
        }
    }
}
