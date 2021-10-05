using System.Collections;
using System.Collections.Generic;
//using Unity.Mathematics;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public enum Direction
    {
        up, down, left, right
    };
    public Direction direction;

    [Header("Room Information")]
    public GameObject roomPrefab;
    public int roomNumbers;
    public Color startColor, endColor;
    private GameObject beforeEndRoom;
    private GameObject endRoom;

    [Header("Position Control")]
    public Transform generatorPoint;
    public float xOffset;
    public float yOffset;
    public LayerMask roomLayer;

    public List<Room> rooms = new List<Room>();



    public WallType wallType;

    void Start()
    {
        for (int i = 0; i < roomNumbers; i++)
        {
            rooms.Add(Instantiate(roomPrefab, generatorPoint.position, Quaternion.identity).GetComponent<Room>());
            ChangePointPosition();
        }

        rooms[0].GetComponent<SpriteRenderer>().color = startColor;

        beforeEndRoom = rooms[0].gameObject;
        foreach (Room room in rooms)
        {
            if (Mathf.Abs(room.gameObject.transform.position.x) + Mathf.Abs(room.transform.position.y) >= Mathf.Abs(beforeEndRoom.transform.position.x) + Mathf.Abs(beforeEndRoom.transform.position.y))
            {
                beforeEndRoom = room.gameObject;
            }
        }
        bool judgeOneDoor;
        do
        {
            generatorPoint.position = beforeEndRoom.transform.position;
            ChangePointPosition();
            endRoom = Instantiate(roomPrefab, generatorPoint.position, Quaternion.identity);
            rooms.Add(endRoom.GetComponent<Room>());
            //Debug.Log("Ìø¹ýÁËÂð");
            SetUpRooms(rooms[rooms.Count - 1], endRoom.transform.position);

            //endRoom.GetComponent<Room>().roomUp = true;
            //endRoom.GetComponent<Room>().roomDown = true;
            judgeOneDoor = !(endRoom.GetComponent<Room>().roomUp || endRoom.GetComponent<Room>().roomDown || endRoom.GetComponent<Room>().roomLeft) || !(endRoom.GetComponent<Room>().roomUp || endRoom.GetComponent<Room>().roomDown || endRoom.GetComponent<Room>().roomRight) || !(endRoom.GetComponent<Room>().roomUp || endRoom.GetComponent<Room>().roomLeft || endRoom.GetComponent<Room>().roomRight) || !(endRoom.GetComponent<Room>().roomRight || endRoom.GetComponent<Room>().roomDown || endRoom.GetComponent<Room>().roomLeft);
            rooms.Remove(rooms[rooms.Count - 1]);
            if (!judgeOneDoor)
            {
                Destroy(endRoom);
            }
        } while (!judgeOneDoor);
        endRoom.GetComponent<SpriteRenderer>().color = endColor;
        rooms.Add(endRoom.GetComponent<Room>());

        foreach (Room room in rooms)
        {
            //room.doorDown.SetActive(false);
            //room.doorUp.SetActive(false);
            //room.doorLeft.SetActive(false);
            //room.doorRight.SetActive(false);

            SetUpRooms(room, room.transform.position,0);
        }
        //draw the map
    }

    void Update()
    {

    }

    public void ChangePointPosition()
    {
        do
        {
            direction = (Direction)Random.Range(0, 4);
            switch (direction)
            {

                case Direction.up:
                    generatorPoint.position += new Vector3(0, yOffset, 0);
                    break;

                case Direction.down:
                    generatorPoint.position -= new Vector3(0, yOffset, 0);
                    break;

                case Direction.left:
                    generatorPoint.position -= new Vector3(xOffset, 0, 0);
                    break;

                case Direction.right:
                    generatorPoint.position += new Vector3(xOffset, 0, 0);
                    break;

            }
        }
        while (Physics2D.OverlapCircle(generatorPoint.position, 0.2f, roomLayer));

    }

    public void SetUpRooms(Room newRoom, Vector3 roomPosition,int x)
    {
        newRoom.roomUp = Physics2D.OverlapCircle(roomPosition + new Vector3(0, yOffset, 0), 0.2f, roomLayer);
        newRoom.roomDown = Physics2D.OverlapCircle(roomPosition + new Vector3(0, -yOffset, 0), 0.2f, roomLayer);
        newRoom.roomLeft = Physics2D.OverlapCircle(roomPosition + new Vector3(-xOffset, 0, 0), 0.2f, roomLayer);
        newRoom.roomRight = Physics2D.OverlapCircle(roomPosition + new Vector3(xOffset, 0, 0), 0.2f, roomLayer);

        if(newRoom.roomUp)
        {
            if(newRoom.roomDown)
            {
                if(newRoom.roomLeft)
                {
                    if(newRoom.roomRight)
                    {
                        Instantiate(wallType.fourDoors, roomPosition, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(wallType.tripleUDL, roomPosition, Quaternion.identity);
                    }
                }
                else if(newRoom.roomRight)
                {
                    Instantiate(wallType.tripleUDR, roomPosition, Quaternion.identity);
                }
                else
                {
                    Instantiate(wallType.doubleUD, roomPosition, Quaternion.identity);
                }
            }
            else if(newRoom.roomLeft)
            {
                if(newRoom.roomRight)
                {
                    Instantiate(wallType.tripleULR, roomPosition, Quaternion.identity);
                }
                else
                {
                    Instantiate(wallType.doubleUL, roomPosition, Quaternion.identity);
                }
            }
            else if(newRoom.roomRight)
            {
                Instantiate(wallType.doubleUR, roomPosition, Quaternion.identity);
            }
            else
            {
                Instantiate(wallType.singleUp, roomPosition, Quaternion.identity);
            }
        }
        else if(newRoom.roomDown)
        {
            if(newRoom.roomLeft)
            {
                if(newRoom.roomRight)
                {
                    Instantiate(wallType.tripleDLR, roomPosition, Quaternion.identity);
                }
                else
                {
                    Instantiate(wallType.doubleDL, roomPosition, Quaternion.identity);
                }
            }
            else if(newRoom.roomRight)
            {
                Instantiate(wallType.doubleDR, roomPosition, Quaternion.identity);
            }
            else
            {
                Instantiate(wallType.singleDown, roomPosition, Quaternion.identity);
            }
        }
        else if(newRoom.roomLeft)
        {
            if(newRoom.roomRight)
            {
                Instantiate(wallType.doubleLR, roomPosition, Quaternion.identity);
            }
            else
            {
                Instantiate(wallType.singleLeft, roomPosition, Quaternion.identity);
            }
        }
        else
        {
            Instantiate(wallType.singleRight, roomPosition, Quaternion.identity);

        }
    }

    public void SetUpRooms(Room newRoom, Vector3 roomPosition)
    {
        newRoom.roomUp = Physics2D.OverlapCircle(roomPosition + new Vector3(0, yOffset, 0), 0.2f, roomLayer);
        newRoom.roomDown = Physics2D.OverlapCircle(roomPosition + new Vector3(0, -yOffset, 0), 0.2f, roomLayer);
        newRoom.roomLeft = Physics2D.OverlapCircle(roomPosition + new Vector3(-xOffset, 0, 0), 0.2f, roomLayer);
        newRoom.roomRight = Physics2D.OverlapCircle(roomPosition + new Vector3(xOffset, 0, 0), 0.2f, roomLayer);

    }



    [System.Serializable]
    public class WallType
    {
        public GameObject singleLeft, singleRight, singleUp, singleDown,
                          doubleUD, doubleUL, doubleUR, doubleDL, doubleDR, doubleLR,
                          tripleUDL, tripleUDR, tripleULR, tripleDLR,
                          fourDoors;
    }

}
