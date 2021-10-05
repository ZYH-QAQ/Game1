using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterInformation : MonoBehaviour
{
    public float life;
    public float speed;
    public float walkingSpeed;
    public bool angry;
    public float angryRange = 5;
    public float power;
    public bool attackByTouch;
    public float width;
    public float hight;
    public float hitBoxWidth;
    public float hitBoxHight;
    GameObject Player;
    Transform childTrigger;
    public LayerMask playerLayer;
    private float unattackableTime=1;
    private float settingSpeed;
    // Start is called before the first frame update
    void Start()
    {
        settingSpeed = speed;
        Player = GameObject.Find("Player");
        this.gameObject.GetComponent<MonsterChase>().enabled = false;
        childTrigger = this.gameObject.transform.Find("Trigger");
        childTrigger.gameObject.GetComponent<MonsterWandering>().enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        if(angry)
        {
            this.gameObject.GetComponent<MonsterChase>().enabled = true;
            childTrigger.gameObject.GetComponent<MonsterWandering>().enabled = false;
        }
        else
        {
            this.gameObject.GetComponent<MonsterChase>().enabled = false;
            childTrigger.gameObject.GetComponent<MonsterWandering>().enabled = true;
        }
        //Debug.Log(Vector3.Distance(this.transform.position, Player.transform.position));
        //Debug.Log("Monster"+this.transform.position);
        //Debug.Log("Player"+Player.transform.position);

        if (Vector3.Distance(this.transform.position,Player.transform.position)<=angryRange)
        {
            angry = true;
        }

        if(attackByTouch)
        {

            bool touch = Physics2D.OverlapArea(new Vector2(this.transform.position.x + width / 2, this.transform.position.y + hight / 2), new Vector2(this.transform.position.x - width / 2, this.transform.position.y - hight / 2), playerLayer);
            if(touch&&unattackableTime>=1)
            {
                Player.GetComponent<PlayerLifeSystem>().HitPlayer(power);
                unattackableTime = 0;
            }
            if(touch)
            {
                speed=0;
            }
            if(!touch)
            {
                speed = settingSpeed;
            }
        }
        unattackableTime += Time.deltaTime;
    }
}
