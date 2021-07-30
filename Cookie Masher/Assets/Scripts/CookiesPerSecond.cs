using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq.Expressions;

public class CookiesPerSecond : MonoBehaviour
{
    public static CookiesPerSecond instance;

    public List<BuildingButton> buildings = new List<BuildingButton>();
    public List<UpgradeButton> upgrades = new List<UpgradeButton>();

    public float cps;
    public TextMeshProUGUI cpsText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        StartCoroutine(BakeCookies());
    }

    public void UpdateCPS()
    {
        cps = 0;
        foreach (BuildingButton build in buildings)
        {
            cps += build.cps * build.quantity;
        }
        cpsText.text = "per second: " + cps.ToString();
    }

    IEnumerator BakeCookies()
    {
        yield return new WaitForSeconds(1);
        PlayerInventory.instance.cookies += cps;
        StartCoroutine(BakeCookies());
    }
}
