using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI nameText, costText, descriptionText;
    public string upgradeName, description;
    public float cost;
    public Button button;
    public GameObject panel;

    public bool unlocked = false;

    public void Initialize(string myName, float myCost, string myDescription)
    {
        button = gameObject.GetComponent<Button>();
        gameObject.name = myName + " Button";
        upgradeName = myName;
        cost = myCost;
        description = myDescription;
        icon.sprite = Resources.Load<Sprite>(myName);
        UpdateUI();
    }

    public void UpdateUI()
    {
        nameText.text = upgradeName;
        costText.text = cost.ToString();
        descriptionText.text = description;
        if (unlocked)
            gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInventory.instance.cookies < cost) { button.interactable = false; }
        else { button.interactable = true; }
    }

    void OnMouseEnter()
    {
        panel.gameObject.SetActive(true);
    }
    void OnMouseExit()
    {
        panel.gameObject.SetActive(false);
    }
}
