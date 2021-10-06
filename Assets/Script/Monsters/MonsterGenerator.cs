using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGenerator : MonoBehaviour
{
    int roomClass = 0;
    GameObject roomGenerator;
    public bool judgeIfGenerate = false;
    public GameObject monster1;
    public GameObject monster2;
    public GameObject monster3;
    public GameObject monster4;
    public GameObject boss;
    public LayerMask roomLayer;

    GameObject monsters;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        monsters = GameObject.Find("Monsters");
        roomGenerator = GameObject.Find("RoomGenerator");
        for (int i = 0; i < roomGenerator.GetComponent<RoomGenerator>().rooms.Count; i++)
        {
            if (this.gameObject.transform.parent.GetComponent<Room>() == roomGenerator.GetComponent<RoomGenerator>().rooms[i])
            {
                if (i % 3 == 1 && i != 10)
                {
                    roomClass = 1;
                    break;
                }
                else if (i % 3 == 2)
                {
                    roomClass = 2;
                    break;
                }
                else if (i % 3 == 0 && i != 0)
                {
                    roomClass = 3;
                    break;
                }
                else if (i == 0)
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
        if (judgeIfGenerate)
        {
            GenerateMonster();
            if (this.gameObject.transform.parent.GetComponent<Room>() != roomGenerator.GetComponent<RoomGenerator>().rooms[10])
            {
                Destroy(this.gameObject);
                player.GetComponent<RecordRooms>().RoomLog++;
            }

            else
            {
                judgeIfGenerate = false;
                this.gameObject.transform.parent.Find("RoomInner").gameObject.GetComponent<InnerRoom>().judgePlayerIn = false;
            }
        }
    }

    private void GenerateMonster()
    {
        if (roomClass == 1)
        {
            int i = 0;
            while (i <= 3)
            {
                float x = Random.Range(-5.0f, 5.0f);
                float y = Random.Range(-1.7f, 1.7f);
                Vector3 roomPosition = this.gameObject.transform.parent.position;

                bool judge = Physics2D.OverlapArea(new Vector2(x - monster1.GetComponent<MonsterInformation>().hitBoxWidth / 2 + roomPosition.x, y + monster1.GetComponent<MonsterInformation>().hitBoxHight / 2 + roomPosition.y), new Vector2(x + monster1.GetComponent<MonsterInformation>().hitBoxWidth / 2 + roomPosition.x, y - monster1.GetComponent<MonsterInformation>().hitBoxHight / 2 + roomPosition.y), roomLayer);
                if (!judge)
                {
                    Instantiate(monster1, roomPosition + new Vector3(x, y, 0), Quaternion.identity, monsters.transform);
                    i++;
                }

            }
            int w = Random.Range(1, 4);
            for (int k = 0; k < w; k++)
            {
                float x = Random.Range(-5.0f, 5.0f);
                float y = Random.Range(-1.7f, 1.7f);
                Vector3 roomPosition = this.gameObject.transform.parent.position;

                Instantiate(monster3, roomPosition + new Vector3(x, y, 0), Quaternion.identity, monsters.transform);

            }

        }

        if (roomClass == 2)
        {
            int i = 0;
            while (i <= 2)
            {
                float x = Random.Range(-5.0f, 5.0f);
                float y = Random.Range(-2f, 2f);
                Vector3 roomPosition = this.gameObject.transform.parent.position;

                bool judge = Physics2D.OverlapArea(new Vector2(x - monster2.GetComponent<MonsterInformation>().hitBoxWidth / 2 + roomPosition.x, y + monster2.GetComponent<MonsterInformation>().hitBoxHight / 2 + roomPosition.y), new Vector2(x + monster2.GetComponent<MonsterInformation>().hitBoxWidth / 2 + roomPosition.x, y - monster2.GetComponent<MonsterInformation>().hitBoxHight / 2 + roomPosition.y), roomLayer);
                if (!judge)
                {
                    Instantiate(monster2, roomPosition + new Vector3(x, y, 0), Quaternion.identity, monsters.transform);
                    i++;
                }

            }
            int w = Random.Range(1, 4);
            for (int k = 0; k < w; k++)
            {
                float x = Random.Range(-5.0f, 5.0f);
                float y = Random.Range(-1.7f, 1.7f);
                Vector3 roomPosition = this.gameObject.transform.parent.position;

                Instantiate(monster3, roomPosition + new Vector3(x, y, 0), Quaternion.identity, monsters.transform);

            }

        }

        if (roomClass == 3)
        {
            int j = Random.Range(1, 4);
            int i = 0;
            while (i < j)
            {


                float x = Random.Range(-5.0f, 5.0f);
                float y = Random.Range(-1.8f, 1.8f);
                Vector3 roomPosition = this.gameObject.transform.parent.position;

                bool judge = Physics2D.OverlapArea(new Vector2(x - monster4.GetComponent<MonsterInformation>().hitBoxWidth / 2 + roomPosition.x, y + monster4.GetComponent<MonsterInformation>().hitBoxHight / 2 + roomPosition.y), new Vector2(x + monster4.GetComponent<MonsterInformation>().hitBoxWidth / 2 + roomPosition.x, y - monster4.GetComponent<MonsterInformation>().hitBoxHight / 2 + roomPosition.y), roomLayer);
                if (!judge)
                {
                    Instantiate(monster4, roomPosition + new Vector3(x, y, 0), Quaternion.identity, monsters.transform);
                    i++;
                }

            }
            i = 0;
            while (i < 4 - j)
            {
                float x = Random.Range(-5.0f, 5.0f);
                float y = Random.Range(-1.7f, 1.7f);
                Vector3 roomPosition = this.gameObject.transform.parent.position;

                bool judge = Physics2D.OverlapArea(new Vector2(x - monster1.GetComponent<MonsterInformation>().hitBoxWidth / 2 + roomPosition.x, y + monster1.GetComponent<MonsterInformation>().hitBoxHight / 2 + roomPosition.y), new Vector2(x + monster1.GetComponent<MonsterInformation>().hitBoxWidth / 2 + roomPosition.x, y - monster1.GetComponent<MonsterInformation>().hitBoxHight / 2 + roomPosition.y), roomLayer);
                if (!judge)
                {
                    Instantiate(monster1, roomPosition + new Vector3(x, y, 0), Quaternion.identity, monsters.transform);
                    i++;
                }

            }
            int w = Random.Range(1, 4);
            for (int k = 0; k < w; k++)
            {
                float x = Random.Range(-5.0f, 5.0f);
                float y = Random.Range(-1.7f, 1.7f);
                Vector3 roomPosition = this.gameObject.transform.parent.position;

                Instantiate(monster3, roomPosition + new Vector3(x, y, 0), Quaternion.identity, monsters.transform);

            }

        }
        if (roomClass == 4 && player.GetComponent<RecordRooms>().RoomLog == 10)
        {
            GameObject Boss0 = Instantiate(boss, this.transform.position, Quaternion.identity, monsters.transform);
            Boss0.name = "Boss";
            Destroy(this.gameObject);
        }
    }
}
