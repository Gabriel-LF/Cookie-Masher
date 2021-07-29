using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildingButton : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI nameText, costText, quantityText;
    public string buildingName;
    public float cost, cps;
    public int quantity;
    public Button button;

    public void Initialize(string myName, float myCost, float myCPS)
    {
        button = gameObject.GetComponent<Button>();
        gameObject.name = myName + " Button";
        buildingName = myName;
        cost = myCost;
        cps = myCPS;
        icon.sprite = Resources.Load<Sprite>(myName);
        UpdateUI();
    }

    public void UpdateUI()
    {
        nameText.text = buildingName;
        costText.text = cost.ToString();
        quantityText.text = quantity.ToString();
    }

    void Update()
    {
        if(PlayerInventory.instance.cookies < cost) { button.interactable = false; }
        else { button.interactable = true; }
    }
}
