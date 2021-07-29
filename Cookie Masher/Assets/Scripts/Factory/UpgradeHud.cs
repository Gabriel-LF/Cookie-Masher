using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHud : MonoBehaviour
{
    [SerializeField]
    private UpgradeButton upgradePrefab;
    public CookiesPerSecond cps;

    private void OnEnable()
    {
        foreach (string name in BuildingFactory.GetUpgradeNames())
        {
            var button = Instantiate(upgradePrefab);
            button.transform.SetParent(transform, false);
            button.Initialize(name, BuildingFactory.GetUpgrade(name).Cost, BuildingFactory.GetUpgrade(name).Description);
            button.button.onClick.AddListener(delegate { BuildingFactory.GetUpgrade(name).Process(); });
            cps.upgrades.Add(button);
        }
    }
}