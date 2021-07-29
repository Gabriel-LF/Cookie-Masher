using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeatherGlove : Upgrade
{
    public override string Name => "Leather Glove";
    public override string Description => "Clicks are TWICE as efficient.";
    public override string ImprovementToMake => "Extra Hand";
    public override float Cost => 100;

    public override void Process()
    {
        BuildingButton Button = GameObject.Find(ImprovementToMake + " Button").GetComponent<BuildingButton>();
        PlayerInventory.instance.clickPower = PlayerInventory.instance.clickPower * 2;
        Button.cps = Button.cps * 2;
        Button.UpdateUI();

        PlayerInventory.instance.cookies -= Cost;
        UpgradeButton upgrade = GameObject.Find(Name + " Button").GetComponent<UpgradeButton>();
        upgrade.unlocked = true;
        upgrade.gameObject.SetActive(false);
        CookiesPerSecond.instance.UpdateCPS();
    }
}
