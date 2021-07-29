using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Reflection;
using System;
using UnityEngine.UI;

public abstract class Building 
{
    public abstract string Name { get; }
    public abstract float Cost { get; }
    public abstract float CPS { get; }

    public GameObject button;
    public void Process() 
    {
        button = GameObject.Find(Name + " Button");
        button.GetComponent<BuildingButton>().quantity++;
        PlayerInventory.instance.cookies -= button.GetComponent<BuildingButton>().cost;
        button.GetComponent<BuildingButton>().cost += (Cost / 100) * 20;
        button.GetComponent<BuildingButton>().UpdateUI();

        CookiesPerSecond.instance.UpdateCPS();
        CookiesPerSecond.instance.UpdateVisuals(Name);
    }
}
