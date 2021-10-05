using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterChase : MonoBehaviour
{
    Vector3 playerLocation;
    public bool seePlayer;
    public GameObject vision;
    // Start is called before the first frame update
    void Start()
    {
        playerLocation = GameObject.Find("Player").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(vision, this.transform.position, Quaternion.identity, this.transform);
        if(seePlayer)
        {
            playerLocation = GameObject.Find("Player").transform.position;
        }

    }

    private void FixedUpdate()
    {
        this.transform.position += Vector3.Normalize(playerLocation - this.transform.position) * this.gameObject.GetComponent<MonsterInformation>().speed * Time.fixedDeltaTime;
    }

    //���˶����Ƿ���Ŀ��С����������˷�����tag�ģ����жϱ���ס�ˡ�
}
