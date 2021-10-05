using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandscapeGenerator : MonoBehaviour
{
    public GameObject obstacle1;
    public GameObject obstacle2;
    public GameObject obstacle3;
    public GameObject obstacle4;
    public LayerMask roomLayer;

    // Start is called before the first frame update
    void Start()
    {
        AddObject(obstacle4, 8, 8);
        AddObject(obstacle3, 10, 9);
        AddObject(obstacle2, 4, 3);
        AddObject(obstacle1, 5, 3);


    }

    // Update is called once per frame
    void Update()
    {

    }

    void AddObject(GameObject obstacle, float xScale,float yScale)
    {
        int i = 0;
        while (i <= 20)
        {
            float x = Random.Range(-8.0f, 8.0f);
            float y = Random.Range(-4f, 4f);
            Vector3 roomPosition= this.gameObject.transform.position;

            bool judge = Physics2D.OverlapArea(new Vector2(x-xScale/2+roomPosition.x, y+yScale/2+roomPosition.y), new Vector2(x+xScale/2+roomPosition.x,y-yScale/2+roomPosition.y), roomLayer);
            if (!judge)
            {
                Instantiate(obstacle,roomPosition+ new Vector3(x, y, 0), Quaternion.identity);
            }
            i++;
        }
    }
}
