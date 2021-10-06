using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : MonoBehaviour
{
    GameObject Player;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.Normalize(Player.transform.position - this.transform.position)*speed*Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerLifeSystem>().HitPlayer(10);
            Destroy(this.gameObject);
        }
        if(collision.CompareTag("BulletPlayer"))
        {
            Destroy(this.gameObject);
        }
    }
}
