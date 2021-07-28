using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Specialized;

public class PlayerInventory : MonoBehaviour
{
    public float cookies;
    private int intCookie;

    public float clickPower = 1;

    public TextMeshProUGUI cookieText;

    private Vector3 mousePos;
    private Vector3 worldPos;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        intCookie = (Mathf.RoundToInt(cookies));
        cookieText.text = (intCookie + " cookies");
    }

    public void BakeCookie()
    {
        cookies += clickPower;

        mousePos = Input.mousePosition;
        mousePos.z = 1.5f;
        worldPos = cam.ScreenToWorldPoint(mousePos);
        ObjectPooler.Instance.SpawnFromPool("ClickParticle", worldPos, Quaternion.Euler(0, 0, 0));
    }
}
