using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 direction;
    Vector3 newPosition;
    public float speed;
    float damage;
    // Start is called before the first frame update
    void Start()
    {
        if (this.transform.parent != null)
        {
            direction = this.transform.position - this.transform.parent.position;
            newPosition = this.transform.position;
            damage = this.transform.parent.gameObject.GetComponent<MonsterInformation>().power;
        }
    }

    // Update is called once per frame
    void Update()
    {
        newPosition += direction * speed * Time.deltaTime;
        this.transform.position = newPosition;
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if ((screenPosition.y > Screen.height || screenPosition.y < 0) || screenPosition.x > Screen.width || screenPosition.x < 0)
        {
            Destroy(this.gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerLifeSystem>().HitPlayer(damage);
        }
        if (!collision.CompareTag("Monster") && !collision.CompareTag("Ignore") && !collision.CompareTag("BulletPlayer") && !collision.CompareTag("BulletMonster"))
        {
            Destroy(this.gameObject);
        }
    }

}
