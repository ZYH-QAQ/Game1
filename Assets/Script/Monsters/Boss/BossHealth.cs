using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public Text Bosshealth;
    GameObject Boss;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Boss = GameObject.Find("Boss");

        if (Boss != null)
        {
            int nums = (int)(Boss.GetComponent<MonsterLifeSystem>().life / 10);
            Bosshealth.text = "Boss:";

            for (int i = 0; i < nums; i++)
            {
                Bosshealth.text += "-";
            }

        }
        
    }
}
