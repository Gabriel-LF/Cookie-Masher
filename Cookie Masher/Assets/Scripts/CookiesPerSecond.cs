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

    public List<GameObject> hands = new List<GameObject>();
    public List<GameObject> erikas = new List<GameObject>();
    public GameObject erikaBG;
    public List<GameObject> farms = new List<GameObject>();
    public GameObject farmBG;
    public List<GameObject> mines = new List<GameObject>();
    public GameObject mineBG;
    public List<GameObject> factorys = new List<GameObject>();
    public GameObject factoryBG;

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

    public void UpdateVisuals(string name)
    {
        BuildingButton handButton = GameObject.Find("Extra Hand Button").GetComponent<BuildingButton>();
        BuildingButton erikaButton = GameObject.Find("Edu's Mom Button").GetComponent<BuildingButton>();
        BuildingButton farmButton = GameObject.Find("Bean Farm Button").GetComponent<BuildingButton>();
        BuildingButton mineButton = GameObject.Find("Blocky Mine Button").GetComponent<BuildingButton>();
        BuildingButton factoryButton = GameObject.Find("Evil Factory Button").GetComponent<BuildingButton>();
        switch (name)
        {
            case "Start":

                if (erikaButton.quantity > 0) { erikaBG.SetActive(true); } else { erikaBG.SetActive(false); }
                if (farmButton.quantity > 0) { farmBG.SetActive(true); } else { farmBG.SetActive(false); }
                if (mineButton.quantity > 0) { mineBG.SetActive(true); } else { mineBG.SetActive(false); }
                if (factoryButton.quantity > 0) { factoryBG.SetActive(true); } else { factoryBG.SetActive(false); }

                int i = 0;
                foreach(GameObject hand in hands)
                {
                    if(i < handButton.quantity) 
                    { hand.SetActive(true); hand.transform.localRotation = Quaternion.Euler(0, 0, i * 7.5f); } 
                    else { hand.SetActive(false); }
                    i++;
                }
                i = 0;
                foreach (GameObject erika in erikas)
                {
                    if (i < erikaButton.quantity)
                    { erika.SetActive(true); }
                    else { erika.SetActive(false); }
                    i++;
                }
                i = 0;
                foreach (GameObject farm in farms)
                {
                    if (i < farmButton.quantity)
                    { farm.SetActive(true); }
                    else { farm.SetActive(false); }
                    i++;
                }
                i = 0;
                foreach (GameObject mine in mines)
                {
                    if (i < mineButton.quantity)
                    { mine.SetActive(true); }
                    else { mine.SetActive(false); }
                    i++;
                }
                i = 0;
                foreach (GameObject factory in factorys)
                {
                    if (i < factoryButton.quantity)
                    { factory.SetActive(true); }
                    else { factory.SetActive(false); }
                    i++;
                }
                break;
            case "Extra Hand":
                if(handButton.quantity <= hands.Count)
                {
                    hands[handButton.quantity - 1].SetActive(true);
                    hands[handButton.quantity - 1].transform.localRotation = Quaternion.Euler(0, 0, (handButton.quantity - 1) * 7.5f);
                }
                break;
            case "Edu's Mom":
                if (erikaButton.quantity <= erikas.Count)
                {
                    erikas[erikaButton.quantity - 1].SetActive(true);
                    erikaBG.SetActive(true);
                }
                break;
            case "Bean Farm":
                if (farmButton.quantity <= farms.Count)
                {
                    farms[farmButton.quantity - 1].SetActive(true);
                    farmBG.SetActive(true);
                }
                break;
            case "Blocky Mine":
                if (mineButton.quantity <= mines.Count)
                {
                    mines[mineButton.quantity - 1].SetActive(true);
                    mineBG.SetActive(true);
                }
                break;
            case "Evil Factory":
                if (factoryButton.quantity <= factorys.Count)
                {
                    factorys[factoryButton.quantity - 1].SetActive(true);
                    factoryBG.SetActive(true);
                }
                break;
            default:
                Debug.Log("Nenhuma construção com esse nome");
                return;
        }
    }
}
