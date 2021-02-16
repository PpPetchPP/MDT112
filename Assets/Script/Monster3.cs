using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster3 : MonoBehaviour
{
    bool attack = false;
    public Monster2 monster2;
    public MonsterBoss monsterBoss;

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
            attack = true;
            monster2.Hit(attack);
            monsterBoss.Hit(attack);
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            attack = false;
            monster2.Hit(attack);
            monsterBoss.Hit(attack);
        }
    }
}
