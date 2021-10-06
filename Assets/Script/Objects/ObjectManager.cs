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


    void Start()
    {
        BombNum = 3;
        TimeSlowerNum = 2;
        FireBulletNum = 5;
        IceBulletNum = 5;
        FrozeFogNum = 7;
        SacrificeNum = 2;
    }

    // Update is called once per frame
    void Update()
    {
        selection += Input.GetAxis("Mouse ScrollWheel")*10;
        selection1 = (int)selection % 7;
        switch(selection1)
        {
            case 0:
                Objects.text = "Bomb x " + BombNum;
                if(BombNum>0&&Input.GetKeyDown(KeyCode.Space))
                {
                    BombNum--;
                }
                break;
        }

    }
}
