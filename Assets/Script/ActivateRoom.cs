using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRoom : MonoBehaviour
{
    public LayerMask monsterLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapArea(new Vector2(this.gameObject.transform.parent.position.x + 9, this.gameObject.transform.parent.position.y + 5), new Vector2(this.gameObject.transform.parent.position.x - 9, this.gameObject.transform.parent.position.y - 5), monsterLayer))
        {


            this.gameObject.transform.parent.gameObject.GetComponent<Room>().judgeMonster = true;
        }
        else
        {
            this.gameObject.transform.parent.gameObject.GetComponent<Room>().judgeMonster = false; 

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("����������µķ��䣡");
            if(CameraController.instance!=null)
            CameraController.instance.UpdateTarget(this.gameObject.transform.parent.transform);
            //��Ҫ���ɹ���,���������ֱ����monstergenerator
            if(this.gameObject.transform.parent.gameObject.transform.Find("MonsterGenerator"))
            this.gameObject.transform.parent.gameObject.transform.Find("MonsterGenerator").GetComponent<MonsterGenerator>().judgeIfGenerate = true;

        }
    }
}
