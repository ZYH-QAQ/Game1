using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject monsterBullet;
    float time = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if(this.GetComponent<MonsterInformation>().angry)
        {
            if (time >= 3)
            {
                Shooting();
                time = 0;
            }
            time+=Time.deltaTime;

        }

    }

    void Shooting()
    {
        for (int i = 0; i < 6; i++)
        {
            Instantiate(monsterBullet, this.transform.position + Quaternion.AngleAxis(60f * i, new Vector3(0, 0, 1)) * this.transform.up, Quaternion.identity,this.transform);
        }
    }
}
