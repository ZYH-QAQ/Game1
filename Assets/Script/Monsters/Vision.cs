using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    public float lightSpeed;
    Vector3 direction;
    GameObject target;
    Vector3 nowPosition;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        direction = Vector3.Normalize(target.transform.position - this.transform.position);
        nowPosition = this.gameObject.transform.parent.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        nowPosition += direction * lightSpeed * Time.deltaTime;
        this.transform.position =nowPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag("Player")&&!collision.CompareTag("Ignore")&&!collision.CompareTag("Monster"))
        {
            this.transform.parent.gameObject.GetComponent<MonsterChase>().seePlayer = false;
            Destroy(this.gameObject);
        }
        if(collision.CompareTag("Player"))
        {
            this.transform.parent.gameObject.GetComponent<MonsterChase>().seePlayer = true;
            Destroy(this.gameObject);

        }
    }

}
