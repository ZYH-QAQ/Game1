using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player22 : MonoBehaviour
{
    public GameObject myPrefab;
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0;
        transform.up = Vector3.Normalize(mouse - transform.position);

        
        if(Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(myPrefab);
        bullet.transform.position =this.transform.position+ this.transform.up;
        //Debug.Log(this.transform.position);
        //Debug.Log(bullet.transform.position);
        bullet.name = "my_bullet";
    }
}
