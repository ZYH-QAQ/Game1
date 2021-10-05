using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class machine_gun : MonoBehaviour
{
    public GameObject myPrefab;
    float deltaT;
    public float setDeltaT = 0.1f;

    void Start()
    {
        
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
            GameObject bullet = Instantiate(myPrefab);
            bullet.transform.position = this.transform.position + this.transform.up;
            bullet.name = "my_bullet";
            deltaT = 0;
        }
        deltaT += Time.deltaTime;
    }
}
