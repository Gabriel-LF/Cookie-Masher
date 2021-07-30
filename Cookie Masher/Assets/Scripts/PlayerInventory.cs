using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Specialized;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance;

    public float cookies;
    private int intCookie;

    public float clickPower = 1;
    public int rollingPins = 0;
    private float pinPower;

    public TextMeshProUGUI cookieText, currentName, inputName, clickPowerText;

    private Vector3 mousePos, worldPos;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        intCookie = (Mathf.RoundToInt(cookies));
        cookieText.text = (intCookie + " cookies");
    }

    public void BakeCookie()
    {
        pinPower = (CookiesPerSecond.instance.cps / 100) * rollingPins;

        clickPowerText.text = "+" + (clickPower + pinPower).ToString();
        cookies += clickPower + pinPower;

        mousePos = Input.mousePosition;
        mousePos.z = 1.5f;
        worldPos = cam.ScreenToWorldPoint(mousePos);
        ObjectPooler.Instance.SpawnFromPool("ClickParticle", worldPos, Quaternion.Euler(0, 0, 0));
    }

    public void NameChange()
    {
        currentName.text = inputName.text;
    }
}
