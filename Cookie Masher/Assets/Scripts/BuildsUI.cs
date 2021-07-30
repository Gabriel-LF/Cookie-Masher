using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class BuildsUI : MonoBehaviour
{
    public GameObject[] builds;
    public GameObject BG;
    public string myName;

    public BuildingButton button;

    void Start()
    {
        button = GameObject.Find(myName + " Button").GetComponent<BuildingButton>();
    }

    public void UpdateVisuals()
    {
        if (button.quantity > 0) { BG.SetActive(true); } else { BG.SetActive(false); }

        int i = 0;
        foreach (GameObject build in builds)
        {
            if (i < button.quantity){ build.SetActive(true); } else { build.SetActive(false); }
            i++;
        }
    }
    
}