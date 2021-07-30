using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BuildingHud : MonoBehaviour
{
    [SerializeField]
    private BuildingButton buildingPrefab;
    public CookiesPerSecond cps;

    private void OnEnable()
    {
        foreach (string name in BuildingFactory.GetBuildingNames())
        {
            var button = Instantiate(buildingPrefab);
            button.transform.SetParent(transform, false);
            button.Initialize(name, BuildingFactory.GetBuilding(name).Cost, BuildingFactory.GetBuilding(name).CPS);
            button.button.onClick.AddListener(delegate { BuildingFactory.GetBuilding(name).Process(); });
            cps.buildings.Add(button);
            ReorderChildren();
        }
    }

    private void ReorderChildren()
    {
        BuildingButton[] count = GetComponentsInChildren<BuildingButton>();
        BuildingButton[] countOrdered = count.OrderBy(go => go.cost).ToArray();
        for (int i = 0; i < countOrdered.Length; i++)
        {
            countOrdered[i].transform.SetSiblingIndex(i);
        }
    }
}
