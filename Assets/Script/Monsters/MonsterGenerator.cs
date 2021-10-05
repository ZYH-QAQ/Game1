using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGenerator : MonoBehaviour
{
    int roomClass=0;
    GameObject roomGenerator;
    public bool judgeIfGenerate = false;
    public GameObject monster1;
    public GameObject monster2;
    public GameObject monster3;
    public LayerMask roomLayer;

    // Start is called before the first frame update
    void Start()
    {
        roomGenerator = GameObject.Find("RoomGenerator");
        for (int i = 0; i < roomGenerator.GetComponent<RoomGenerator>().rooms.Count; i++)
        {
            if(this.gameObject.transform.parent.GetComponent<Room>()== roomGenerator.GetComponent<RoomGenerator>().rooms[i])
            {
                if (i % 3 == 1)
                {
                    roomClass = 1;
                    break;
                }
                else if(i%3==2&&i!=11)
                {
                    roomClass = 2;
                    break;
                }
                else if(i%3==0&&i!=0)
                {
                    roomClass = 3;
                    break;
                }
                else if(i==0)
                {
                    roomClass = 0;
                }
                else
                {
                    roomClass = 4;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(judgeIfGenerate)
        {
            GenerateMonster();
            Destroy(this.gameObject);
        }
    }

    private void GenerateMonster()
    {
        if(roomClass==1)
        {
            int i = 0;
            while(i<=3)
            {
                float x = Random.Range(-7.0f, 7.0f);
                float y = Random.Range(-3f, 3f);
                Vector3 roomPosition = this.gameObject.transform.parent.position;

                bool judge = Physics2D.OverlapArea(new Vector2(x - monster1.GetComponent<MonsterInformation>().hitBoxWidth / 2 + roomPosition.x, y + monster1.GetComponent<MonsterInformation>().hitBoxHight / 2 + roomPosition.y), new Vector2(x + monster1.GetComponent<MonsterInformation>().hitBoxWidth / 2 + roomPosition.x, y - monster1.GetComponent<MonsterInformation>().hitBoxHight / 2 + roomPosition.y), roomLayer);
                if (!judge)
                {
                    Instantiate(monster1, roomPosition + new Vector3(x, y, 0), Quaternion.identity);
                    i++;
                }

            }
        }

        if (roomClass == 2)
        {
            int i = 0;
            while (i <= 2)
            {
                float x = Random.Range(-7.0f, 7.0f);
                float y = Random.Range(-3f, 3f);
                Vector3 roomPosition = this.gameObject.transform.parent.position;

                bool judge = Physics2D.OverlapArea(new Vector2(x - monster2.GetComponent<MonsterInformation>().hitBoxWidth / 2 + roomPosition.x, y + monster2.GetComponent<MonsterInformation>().hitBoxHight / 2 + roomPosition.y), new Vector2(x + monster2.GetComponent<MonsterInformation>().hitBoxWidth / 2 + roomPosition.x, y - monster2.GetComponent<MonsterInformation>().hitBoxHight / 2 + roomPosition.y), roomLayer);
                if (!judge)
                {
                    Instantiate(monster2, roomPosition + new Vector3(x, y, 0), Quaternion.identity);
                    i++;
                }

            }
        }

    }
}
