using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectManager : MonoBehaviour
{
    public int BombNum;
    public int TimeSlowerNum;
    public int FireBulletNum;
    public int IceBulletNum;
    public int FrozeFogNum;
    public int SacrificeNum;
    public int BloodBottleNum;

    public Text Objects;

    float selection = 0;
    int selection1;
    public GameObject IceBullet;
    public GameObject FireBullet;
    public GameObject OriBullet;
    public GameObject Bomb;
    GameObject monsters;

    float lastingTime1=60;
    float lastingTime2 = 60;
    //float bombTime = 3;

    bool judgeFireBulletOn =false;
    bool judgeIceBulletOn = false;
    //bool judgeBomb = false;

    void Start()
    {
        BombNum = 3;
        TimeSlowerNum = 2;
        FireBulletNum = 5;
        IceBulletNum = 5;
        FrozeFogNum = 7;
        SacrificeNum = 2;
        BloodBottleNum = 15;

        monsters = GameObject.Find("Monsters");

    }

    // Update is called once per frame
    void Update()
    {
        selection += (7+Input.GetAxis("Mouse ScrollWheel") * 10)%7;
        selection1 = (int)selection % 7;
        switch (selection1)
        {
            case 0:
                Objects.text = "Bomb x " + BombNum;
                if (BombNum > 0 && Input.GetKeyDown(KeyCode.Space))
                {
                    Instantiate(Bomb, this.transform.position, Quaternion.identity);
                    BombNum--;
                }
                break;
            case 1:
                Objects.text = "TimeSlower x " + TimeSlowerNum;
                if (TimeSlowerNum > 0 && Input.GetKeyDown(KeyCode.Space))
                {
                    TimeSlowerNum--;
                }
                break;
            case 2:
                Objects.text = "FireBullet x " + FireBulletNum;
                if (FireBulletNum > 0 && Input.GetKeyDown(KeyCode.Space))
                {
                    judgeFireBulletOn = true;
                    this.gameObject.GetComponent<player22>().myPrefab = FireBullet;
                    FireBulletNum--;
                }
                break;
            case 3:
                Objects.text = "IceBullet x " + IceBulletNum;
                if (IceBulletNum > 0 && Input.GetKeyDown(KeyCode.Space))
                {
                    judgeIceBulletOn = true;
                    this.gameObject.GetComponent<player22>().myPrefab = IceBullet;
                    IceBulletNum--;
                }
                break;
            case 4:
                Objects.text = "FrozeFog x " + FrozeFogNum;
                if (FrozeFogNum > 0 && Input.GetKeyDown(KeyCode.Space))
                {
                    FrozeFogNum--;
                }
                break;
            case 5:
                Objects.text = "Sacrifice x " + SacrificeNum;
                if (SacrificeNum > 0 && Input.GetKeyDown(KeyCode.Space))
                {
                    float life = this.gameObject.GetComponent<PlayerLifeSystem>().life;
                    this.gameObject.GetComponent<PlayerLifeSystem>().life = life / 2;
                    foreach  (Transform children in monsters.transform)
                    {
                        if (children.gameObject.GetComponent<MonsterLifeSystem>() != null)
                            children.gameObject.GetComponent<MonsterLifeSystem>().HitMonster(life / 2);
                        else
                            Destroy(children.gameObject);
                    }
                    SacrificeNum--;
                }
                break;
            case 6:
                Objects.text = "BloodBottle x " + BloodBottleNum;
                if (BloodBottleNum > 0 && Input.GetKeyDown(KeyCode.Space))
                {
                    this.gameObject.GetComponent<PlayerLifeSystem>().life += 20;
                    BloodBottleNum--;
                }
                break;

        }


        if(judgeFireBulletOn)
        {
            lastingTime1 -= Time.deltaTime;

        }
        if(judgeIceBulletOn)
        {
            lastingTime2 -= Time.deltaTime;
        }
        if (!((judgeFireBulletOn&&lastingTime1>0)||(judgeIceBulletOn&&lastingTime2>0)))
        {
            this.gameObject.GetComponent<player22>().myPrefab = OriBullet;
        }
        if(!(lastingTime1>=0))
        {
            judgeFireBulletOn = false;
            lastingTime1 = 60;
        }
        if (!(lastingTime2 >= 0))
        {
            judgeFireBulletOn = false;
            lastingTime1 = 60;
        }
        


    }


}
