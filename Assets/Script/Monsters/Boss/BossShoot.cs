using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    float deltaT = 0.12f;
    public GameObject bullet;
    float omega;
    float t0;
    // Start is called before the first frame update
    void Start()
    {
        t0 = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        deltaT += Time.deltaTime;
        omega = Mathf.Sin((Time.realtimeSinceStartup - t0)*0.5f);
        this.gameObject.transform.Rotate(new Vector3(0, 0, 1) * omega * Time.deltaTime*100);
        if(deltaT>=0.12)
        {
            Instantiate(bullet, this.transform.position + this.transform.up, Quaternion.identity,this.gameObject.transform);
            Instantiate(bullet, this.transform.position - this.transform.up, Quaternion.identity, this.gameObject.transform);

            deltaT = 0;
        }
    }
}
