using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLifeSystem : MonoBehaviour
{
    public float life;
    public Sprite hurtImage;
    public Sprite oriImage;
    private float time = 0;
    private bool judgeHurt;
    public GameObject GreenFog;
    GameObject player;

    private void OnDestroy()
    {
        if(this.gameObject.GetComponent<BossBehaviour>()!=null)
        {
            player.GetComponent<Win>().judgeWin = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        life = this.gameObject.GetComponent<MonsterInformation>().life;
    }

    // Update is called once per frame
    void Update()
    {
        if (judgeHurt)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = hurtImage;

            if (time <= 0.2)
            {
                time += Time.deltaTime;
            }
            else
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = oriImage;
                time = 0;
                judgeHurt = false;
            }
        }

        if (life<=0)
        {
            Destroy(this.gameObject);
        }
    }

    public void HitMonster(float damage)
    {
        this.life -= damage;
        this.gameObject.GetComponent<MonsterInformation>().angry = true;
        judgeHurt = true;
        if(this.gameObject.GetComponent<GreenGeorge>()!=null)
            Instantiate(GreenFog, this.transform.position, Quaternion.identity);

    }
}
