using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour
{
    public GameObject bullet;
    float deltaT;
    public float setDeltaT = 0.25f;

    void Start()
    {
        bullet = this.GetComponent<player22>().myPrefab;

    }

    // Update is called once per frame
    void Update()
    {
        bullet = this.GetComponent<player22>().myPrefab;

        if (Input.GetMouseButton(0))
        {
            Fire();
        }

    }
    void Fire()
    {
        if (deltaT >= setDeltaT)
        {
            GameObject bullet = Instantiate(this.bullet);
            bullet.transform.position = this.transform.position + this.transform.up;
            //bullet.name = "my_bullet";
            deltaT = 0;
        }
        deltaT += Time.deltaTime;
    }
}
