using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public PlayerInventory pi;
    public CookiesPerSecond cps;
    public bool hasSaved = false;

    // Start is called before the first frame update
    void Start()
    {
        hasSaved = PlayerPrefsX.GetBool("hasSaved");
        if (hasSaved) { LoadGame(); }
        StartCoroutine(AutoSave());
    }

    public void SaveGame()
    {
        hasSaved = true;
        PlayerPrefsX.SetBool("hasSaved", hasSaved);

        PlayerPrefs.SetFloat("Cookies", pi.cookies);
        PlayerPrefs.SetFloat("clickPower", pi.clickPower);
        PlayerPrefs.SetInt("rollingPins", pi.rollingPins);
        PlayerPrefs.SetString("Name", pi.currentName.text);
        foreach (BuildingButton build in cps.buildings)
        {
            PlayerPrefs.SetFloat(build.buildingName + "cost", build.cost);
            PlayerPrefs.SetFloat(build.buildingName + "cps", build.cps);
            PlayerPrefs.SetInt(build.buildingName + "quantity", build.quantity);
        }
        foreach (UpgradeButton upgrade in cps.upgrades)
        {
            PlayerPrefsX.SetBool(upgrade.upgradeName + "unlocked", upgrade.unlocked);
        }
    }

    public void LoadGame()
    {
        pi.cookies = PlayerPrefs.GetFloat("Cookies");
        pi.clickPower = PlayerPrefs.GetFloat("clickPower");
        pi.rollingPins = PlayerPrefs.GetInt("rollingPins");
        pi.currentName.text = PlayerPrefs.GetString("Name"); if(pi.currentName.text == null) pi.currentName.text = "My Bakery";
        foreach (BuildingButton build in cps.buildings)
        {
            build.cost = PlayerPrefs.GetFloat(build.buildingName + "cost");
            build.cps = PlayerPrefs.GetFloat(build.buildingName + "cps");
            build.quantity = PlayerPrefs.GetInt(build.buildingName + "quantity");
            build.UpdateUI();
        }
        foreach (UpgradeButton upgrade in cps.upgrades)
        {
            upgrade.unlocked = PlayerPrefsX.GetBool(upgrade.upgradeName + "unlocked");
            upgrade.UpdateUI();
        }
        cps.UpdateCPS();
        cps.UpdateVisuals("Start");
    }

    IEnumerator AutoSave()
    {
        yield return new WaitForSeconds(60);
        SaveGame();
        StartCoroutine(AutoSave());
    }

    public void WipeSave()
    {
        pi.cookies = 0;
        pi.clickPower = 1;
        pi.rollingPins = 0;
        pi.currentName.text = "My Bakery";
        foreach (BuildingButton build in cps.buildings)
        {
            build.cost = BuildingFactory.GetBuilding(build.buildingName).Cost;
            build.cps = BuildingFactory.GetBuilding(build.buildingName).CPS;
            build.quantity = 0;
            build.UpdateUI();
        }
        foreach (UpgradeButton upgrade in cps.upgrades)
        {
            upgrade.unlocked = false;
            upgrade.gameObject.SetActive(true);
        }
        cps.UpdateCPS();
        cps.UpdateVisuals("Start");

        SaveGame();
    }
}
