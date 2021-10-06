using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    float time;
    GameObject monsters;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        time = 3;
        monsters = GameObject.Find("Monsters");
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(time<=0)
        {
            foreach (Transform children in monsters.transform)
            {
                if((children.position-this.transform.position).sqrMagnitude<=3)
                {
                    children.gameObject.GetComponent<MonsterLifeSystem>().HitMonster(50);
                }
            }
            if((this.transform.position-player.transform.position).sqrMagnitude<=3)
            {
                player.GetComponent<PlayerLifeSystem>().life -= 50;
            }
            Destroy(this.gameObject);
        }
    }
}
