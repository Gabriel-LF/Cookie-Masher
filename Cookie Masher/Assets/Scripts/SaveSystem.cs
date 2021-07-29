using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public PlayerInventory pi;
    public CookiesPerSecond cps;

    // Start is called before the first frame update
    void Start()
    {
        LoadGame();
        StartCoroutine(AutoSave());
    }

    public void SaveGame()
    {
        PlayerPrefs.SetFloat("Cookies", pi.cookies);
        PlayerPrefs.SetString("Name", pi.currentName.text);
        foreach (BuildingButton build in cps.buildings)
        {
            PlayerPrefs.SetFloat(build.buildingName + "cost", build.cost);
            PlayerPrefs.SetFloat(build.buildingName + "cps", build.cps);
            PlayerPrefs.SetInt(build.buildingName + "quantity", build.quantity);
        }
    }

    public void LoadGame()
    {
        pi.cookies = PlayerPrefs.GetFloat("Cookies");
        pi.currentName.text = PlayerPrefs.GetString("Name"); if(pi.currentName.text == null) pi.currentName.text = "My Bakery";
        foreach (BuildingButton build in cps.buildings)
        {
            build.cost = PlayerPrefs.GetFloat(build.buildingName + "cost");
            build.cps = PlayerPrefs.GetFloat(build.buildingName + "cps");
            build.quantity = PlayerPrefs.GetInt(build.buildingName + "quantity");
            build.UpdateUI();
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
        pi.currentName.text = "My Bakery";
        foreach (BuildingButton build in cps.buildings)
        {
            build.cost = BuildingFactory.GetBuilding(build.buildingName).Cost;
            build.cps = BuildingFactory.GetBuilding(build.buildingName).CPS;
            build.quantity = 0;
            build.UpdateUI();
        }
        cps.UpdateCPS();
        cps.UpdateVisuals("Start");

        SaveGame();
    }
}
