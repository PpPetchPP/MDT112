using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBoss3_4 : MonoBehaviour
{
    bool attack = false;
    public MonsterBoss3 monsterBoss3;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            monsterBoss3.fate();
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            monsterBoss3.fateoff();
        }
    }
}
