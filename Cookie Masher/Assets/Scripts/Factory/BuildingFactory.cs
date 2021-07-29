using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Reflection;
using System;

public static class BuildingFactory
{
    public static Dictionary<string, Type> buildingsByName;
    private static bool IsInitialized => buildingsByName != null;

    public static Dictionary<string, Type> upgradesByName;

    private static void InitializeFactory()
    {
        if (IsInitialized)
            return;

        var buildingTypes = Assembly.GetAssembly(typeof(Building)).GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(Building)));
        var upgradeTypes = Assembly.GetAssembly(typeof(Upgrade)).GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(Upgrade)));

        //Dicionario para encontrar isso por nome depois(pode ser enum/id ao inves de uma string)
        buildingsByName = new Dictionary<string, Type>();
        upgradesByName = new Dictionary<string, Type>();

        // Pegar os nomes e colocar eles no dicionário
        foreach (var type in buildingTypes)
        {
            var tempEffect = Activator.CreateInstance(type) as Building;
            buildingsByName.Add(tempEffect.Name, type);
        }

        foreach (var type in upgradeTypes)
        {
            var tempEffect = Activator.CreateInstance(type) as Upgrade;
            upgradesByName.Add(tempEffect.Name, type);
        }
    }

    public static Building GetBuilding(string buildingType)
    {
        InitializeFactory();

        if (buildingsByName.ContainsKey(buildingType))
        {
            Type type = buildingsByName[buildingType];
            var building = Activator.CreateInstance(type) as Building;
            return building;
        }

        return null;
    }
    public static Upgrade GetUpgrade(string upgradeType)
    {
        InitializeFactory();

        if (upgradesByName.ContainsKey(upgradeType))
        {
            Type type = upgradesByName[upgradeType];
            var upgrade = Activator.CreateInstance(type) as Upgrade;
            return upgrade;
        }

        return null;
    }

    internal static IEnumerable<string> GetBuildingNames()
    {
        InitializeFactory();
        return buildingsByName.Keys;
    }
    internal static IEnumerable<string> GetUpgradeNames()
    {
        InitializeFactory();
        return upgradesByName.Keys;
    }
}
