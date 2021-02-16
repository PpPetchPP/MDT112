using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    [SerializeField] static int money = 0;
    public Text moneyText;
    public Text moneyText2;
    public Inventory inven;
    public Shoot shoot;
    public heart hh;
    public Player player;
    public GameObject TeaErrorBuy;
    public GameObject TeaBuy;
    public GameObject TeaBuy2;
    int tea = 0;

    float sw1 = 0;
    bool sw2 = true;
    bool sw3 = true;
    bool sw4 = true;

    public GameObject SoldOut1;
    public GameObject SoldOut2;
    public GameObject SoldOut3;
    public GameObject SoldOut4;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "Money : " + money;
        moneyText2.text = "Money : " + money;
    }

    public void Reset()
    {
        money = 0;
    }

    public void buyTea()
    {
        if (sw1 < 2)
        {
            if (money >= 10)
            {
                money -= 10;
                if (tea <= 0)
                {
                    tea++;
                    TeaBuy.SetActive(true);
                    inven.buytea();
                    sw1++;
                }
                else if (tea >= 1)
                {
                    tea++;
                    TeaBuy2.SetActive(true);
                    inven.buytea();
                    sw1++;
                }

                if (sw1 >= 2)
                {
                    SoldOut1.SetActive(true);
                }

            }
            else
            {
                TeaErrorBuy.SetActive(true);
                Invoke("cancle", 1);
            }
        }
    }
    public void buyAmmo()
    {
        if (sw2 == true)
        {
            if (money >= 15)
            {
                money -= 15;
                shoot.upgrade();
                sw2 = false;

                if (sw2 == false)
                {
                    SoldOut2.SetActive(true);
                }
            }
            else
            {
                TeaErrorBuy.SetActive(true);
                Invoke("cancle", 1);
            }
        }
    }
    public void buyHearth()
    {
        if (sw3 == true)
        {
            if (money >= 15)
            {
                money -= 15;
                hh.upgrade();
                player.UpgradeH();
                sw3 = false;

                if (sw3 == false)
                {
                    SoldOut3.SetActive(true);
                }
            }
            else
            {
                TeaErrorBuy.SetActive(true);
                Invoke("cancle", 1);
            }
        }
    }
    public void buyShotgun()
    {
        if (sw4 == true)
        {
            if (money >= 15)
            {
                money -= 15;
                shoot.upgrade2();
                sw4 = false;

                if (sw4 == false)
                {
                    SoldOut4.SetActive(true);
                }
            }
            else
            {
                TeaErrorBuy.SetActive(true);
                Invoke("cancle", 1);
            }
        }
    }

    void cancle()
    {
        TeaErrorBuy.SetActive(false);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Coin")
        {
            money++;
        }
    }
}
