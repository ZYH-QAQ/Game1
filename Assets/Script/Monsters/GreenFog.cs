using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenFog : MonoBehaviour
{
    float time = 10;
    //float attackTime=1;
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("Player") != null)
            Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        time -= Time.deltaTime;
        if (time <= 0)
        {
            Destroy(this.gameObject);
        }
        //attackTime += Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //if (attackTime >= 1)
            //{
            Player.GetComponent<PlayerLifeSystem>().HitPlayer(5);
            //attackTime = 0;
            //}
            Destroy(this.gameObject);
        }
    }

}
