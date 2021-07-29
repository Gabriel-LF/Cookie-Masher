using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImportedStove : LeatherGlove
{
    public override string Name => "Imported Stove";
    public override string Description => "Edu's Mom clones are TWICE as efficient";
    public override string ImprovementToMake => "Edu's Mom";
    public override float Cost => 1000;

    public override void Process()
    {
        BuildingButton Button = GameObject.Find(ImprovementToMake + " Button").GetComponent<BuildingButton>();
        Button.cps = Button.cps * 2;
        Button.UpdateUI();

        PlayerInventory.instance.cookies -= Cost;
        UpgradeButton upgrade = GameObject.Find(Name + " Button").GetComponent<UpgradeButton>();
        upgrade.unlocked = true;
        upgrade.gameObject.SetActive(false);
        CookiesPerSecond.instance.UpdateCPS();
    }
}
