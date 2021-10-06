using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    //Vector3 lastPosition;
    private Vector3 direction;
    public float damage;


    public int speed;
    void Start()
    {
        GameObject shooter = GameObject.Find("Player");
        direction = shooter.transform.up;
    }

    void Update()
    {
        //Vector3 direction = Vector3.Normalize(transform.position - lastPosition);
        transform.position += direction * Time.deltaTime * speed;
        //Debug.Log(++i);
        //lastPosition = transform.position;
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if((screenPosition.y>Screen.height||screenPosition.y<0)||screenPosition.x>Screen.width||screenPosition.x<0)
        {
            Destroy(this.gameObject);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            if(collision.gameObject.GetComponent<MonsterLifeSystem>()!=null)
            collision.gameObject.GetComponent<MonsterLifeSystem>().HitMonster(damage);
        }
        if (!collision.CompareTag("Player")&&!collision.CompareTag("Ignore")&& !collision.CompareTag("BulletPlayer")&& !collision.CompareTag("BulletMonster"))
        {
            Destroy(this.gameObject);
        }
    }
}
