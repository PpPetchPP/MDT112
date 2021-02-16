using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buy : MonoBehaviour
{
    public Money money;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tea()
    {
        money.buyTea();                  
    }
    public void ammo()
    {        
        money.buyAmmo();
    }
    public void Heart()
    {
        money.buyHearth();
    }
    public void Shotgun()
    {
        money.buyShotgun();
    }
}
