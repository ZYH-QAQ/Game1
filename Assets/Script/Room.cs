using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject doorUp, doorDown, doorLeft, doorRight;
    public bool roomUp=true, roomDown=true, roomLeft=true, roomRight=true;
    public bool judgeMonster;

    void Start()
    {
        doorDown.SetActive(false);
        doorUp.SetActive(false);
        doorLeft.SetActive(false);
        doorRight.SetActive(false);

    }

    void Update()
    {
        if (this.transform.Find("RoomInner") != null)
        {
            if (judgeMonster && this.transform.Find("RoomInner").gameObject.GetComponent<InnerRoom>().judgePlayerIn)
            {
                doorDown.SetActive(roomDown);
                doorUp.SetActive(roomUp);
                doorLeft.SetActive(roomLeft);
                doorRight.SetActive(roomRight);
                Destroy(this.transform.Find("RoomInner").gameObject);
            }
        }
        if(!judgeMonster)
        {
            doorDown.SetActive(false);
            doorUp.SetActive(false);
            doorLeft.SetActive(false);
            doorRight.SetActive(false);

        }
    }
}
