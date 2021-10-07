using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot2 : MonoBehaviour
{
    float deltaT = 1.5f;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        deltaT += Time.deltaTime;
        if (deltaT >= 1.5)
        {
            for (int i = 1; i <= 20; i++)
            {
                Instantiate(bullet, this.transform.position + Quaternion.AngleAxis(-180 + 18f * i, new Vector3(0, 0, 1)) * this.transform.up, Quaternion.identity, this.gameObject.transform);

            }
            deltaT = 0;
        }
    }
}
