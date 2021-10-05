using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Text HealthText;
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        HealthText.text ="Health: "+Convert.ToString((int)Player.GetComponent<PlayerLifeSystem>().life);
    }

    // Update is called once per frame
    void Update()
    {
        HealthText.text = "Health: " + Convert.ToString((int)Player.GetComponent<PlayerLifeSystem>().life);

    }
}
