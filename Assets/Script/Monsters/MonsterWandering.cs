using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterWandering : MonoBehaviour
{
    Vector3 direction;
    bool changeDirection;
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        int choice = Random.Range(1, 5);
        switch (choice)
        {
            case 1:
                direction = new Vector3(1, 0, 0);
                break;
            case 2:
                direction = new Vector3(-1, 0, 0);
                break;
            case 3:
                direction = new Vector3(0, 1, 0);
                break;
            case 4:
                direction = new Vector3(0, -1, 0);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(time>=2)
        {
            changeDirection = true;
        }
        if(!changeDirection)
        {
            time += Time.deltaTime;
        }
        else
        {
            int choice = Random.Range(1, 4);
            switch (choice)
            {
                case 1:
                    direction = Quaternion.AngleAxis(90f, new Vector3(0, 0, 1)) * direction;
                    //Debug.Log(1);
                    break;
                case 2:
                    direction = Quaternion.AngleAxis(-90f, new Vector3(0, 0, 1)) * direction;
                    //Debug.Log(2);
                    break;
                case 3:
                    direction = Quaternion.AngleAxis(180f, new Vector3(0, 0, 1)) * direction;
                    //Debug.Log(3);
                    break;

            }

            time = 0;
            changeDirection = false;
        }
        this.transform.parent.transform.position += direction * this.transform.parent.gameObject.GetComponent<MonsterInformation>().walkingSpeed * Time.deltaTime;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag("Ignore"))
        {
            //changeDirection = true;
            direction = Quaternion.AngleAxis(90f, new Vector3(0, 0, 1)) * direction;
        }
    }
}
