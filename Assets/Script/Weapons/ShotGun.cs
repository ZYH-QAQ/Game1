using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : MonoBehaviour
{
    public GameObject bullet;
    float deltaT;
    public float setDeltaT = 0.5f;

    void Start()
    {
        bullet = this.GetComponent<player22>().myPrefab;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Fire();
        }

    }
    void Fire()
    {
        if (deltaT >= setDeltaT)
        {
            for (int i = 0; i < 5; i++)
            {
                Instantiate(bullet, this.transform.position + Quaternion.AngleAxis(-40+20f * i, new Vector3(0, 0, 1)) * this.transform.up, Quaternion.identity);
            }
            //bullet.name = "my_bullet";
            deltaT = 0;
        }
        deltaT += Time.deltaTime;
    }
}
