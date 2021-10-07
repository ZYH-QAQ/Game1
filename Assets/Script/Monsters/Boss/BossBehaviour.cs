using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    float timeCircle = 60;
    public GameObject Flies;
    float life;
    float oriLife;
    void Start()
    {
        life = this.gameObject.GetComponent<MonsterLifeSystem>().life;
        oriLife = this.gameObject.GetComponent<MonsterLifeSystem>().life;
    }

    // Update is called once per frame
    void Update()
    {
        if(life> this.gameObject.GetComponent<MonsterLifeSystem>().life)
        {
            Instantiate(Flies, this.transform.position,Quaternion.identity);
            if(this.gameObject.GetComponent<MonsterLifeSystem>().life<=oriLife/3)
            {
                Instantiate(Flies, this.transform.position, Quaternion.identity );
                Instantiate(Flies, this.transform.position, Quaternion.identity);

            }
        }
        life = this.gameObject.GetComponent<MonsterLifeSystem>().life;


        timeCircle -= Time.deltaTime;
        if (timeCircle <= 60 && timeCircle >= 40)
        {
            this.gameObject.GetComponent<BossShoot>().enabled = true;
            this.gameObject.GetComponent<BossShoot2>().enabled = false;
            this.gameObject.GetComponent<Rush>().enabled = false;

        }
        else if (timeCircle <= 40 && timeCircle >= 35)
        {
            this.gameObject.GetComponent<BossShoot>().enabled = false;
            this.gameObject.GetComponent<BossShoot2>().enabled = false;
            this.gameObject.GetComponent<Rush>().enabled = false;


            if (Vector3.Dot(this.transform.up, new Vector3(1, 0, 0)) >= 0)
            {
                this.transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime *36);

            }
            if (Vector3.Dot(this.transform.up, new Vector3(1, 0, 0)) < 0)
            {
                this.transform.Rotate(new Vector3(0, 0, -1) * Time.deltaTime * 36);

            }

        }

        else if (timeCircle <= 35 && timeCircle >= 25)
        {
            this.gameObject.GetComponent<BossShoot>().enabled = false;
            this.gameObject.GetComponent<BossShoot2>().enabled = true;
            this.gameObject.GetComponent<Rush>().enabled = false;

        }
        else if (timeCircle <= 25 && timeCircle >= 20)
        {
            this.gameObject.GetComponent<BossShoot>().enabled = false;
            this.gameObject.GetComponent<BossShoot2>().enabled = false;
            this.gameObject.GetComponent<Rush>().enabled = false;

        }
        else if (timeCircle <= 20 && timeCircle >= 14)
        {
            this.gameObject.GetComponent<BossShoot>().enabled = false;
            this.gameObject.GetComponent<BossShoot2>().enabled = false;
            this.gameObject.GetComponent<Rush>().enabled = true;

        }
        else if (timeCircle <= 14 && timeCircle >= 6)
        {
            this.gameObject.GetComponent<BossShoot>().enabled = false;
            this.gameObject.GetComponent<BossShoot2>().enabled = false;
            this.gameObject.GetComponent<Rush>().enabled = false;

        }
        else if (timeCircle <= 6 && timeCircle > 0)
        {
            this.gameObject.GetComponent<BossShoot>().enabled = false;
            this.gameObject.GetComponent<BossShoot2>().enabled = false;
            this.gameObject.GetComponent<Rush>().enabled = true;

        }





        if (timeCircle<=0)
        {
            timeCircle = 60;
        }
    }
}
