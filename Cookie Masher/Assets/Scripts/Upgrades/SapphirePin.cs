using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SapphirePin : Upgrade
{
    public override string Name => "Sapphire Rolling Pin";
    public override string Description => "Clicking gains 1% of your CpS";
    public override string ImprovementToMake => "None";
    public override float Cost => 50000;

    public override void Process()
    {
        PlayerInventory.instance.rollingPins++;

        PlayerInventory.instance.cookies -= Cost;
        UpgradeButton upgrade = GameObject.Find(Name + " Button").GetComponent<UpgradeButton>();
        upgrade.unlocked = true;
        upgrade.gameObject.SetActive(false);
        CookiesPerSecond.instance.UpdateCPS();
    }
}
