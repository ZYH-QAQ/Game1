using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    //Vector3 lastPosition;
    private Vector3 direction;
    public float damage;
    float angle;

    public int speed;
    void Start()
    {
        GameObject shooter = GameObject.Find("Player");
        direction = shooter.transform.up;
        angle = Vector3.Angle(this.transform.position - shooter.transform.position, new Vector3(0, 1, 0));
        if(Vector3.Dot((this.transform.position - shooter.transform.position),Vector3.right)>=0)
            this.transform.Rotate(new Vector3(0,0,1)*-angle);
        else
            this.transform.Rotate(new Vector3(0, 0, 1) * angle);

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
