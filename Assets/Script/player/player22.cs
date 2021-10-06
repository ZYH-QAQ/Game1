using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player22 : MonoBehaviour
{
    public GameObject myPrefab;
    int selectGun = 0;
    public Text GunType;
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0;
        transform.up = Vector3.Normalize(mouse - transform.position);

        
        //if(Input.GetMouseButtonDown(0))
        //{
        //    Fire();
        //}

        if(Input.GetKeyDown(KeyCode.Q))
        {
            selectGun += 1;
            if(selectGun%3==0)
            {
                GunType.text = "Gun";
                this.gameObject.GetComponent<Gun>().enabled = true;
                this.gameObject.GetComponent<ShotGun>().enabled = false;
                this.gameObject.GetComponent<MachineGun>().enabled = false;

            }
            if (selectGun % 3 == 1)
            {
                GunType.text = "MachineGun";
                this.gameObject.GetComponent<Gun>().enabled = false;
                this.gameObject.GetComponent<ShotGun>().enabled = false;
                this.gameObject.GetComponent<MachineGun>().enabled = true;

            }
            if (selectGun % 3 == 2)
            {
                GunType.text = "ShotGun";
                this.gameObject.GetComponent<Gun>().enabled = false;
                this.gameObject.GetComponent<ShotGun>().enabled = true;
                this.gameObject.GetComponent<MachineGun>().enabled = false;

            }

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
