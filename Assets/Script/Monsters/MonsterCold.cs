using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCold : MonoBehaviour
{
    public Sprite coldSprite;
    public bool cold=false;
    float time=0;
    float oriSpeed;
    // Start is called before the first frame update
    void Start()
    {
     oriSpeed = this.gameObject.GetComponent<MonsterInformation>().speed;

    }

    // Update is called once per frame
    void Update()
    {
        if(cold)
        {
            time = 1;
            cold = false;
        }
        time -= Time.deltaTime;
        if(time<=0)
        {
            time = 0;
            this.gameObject.GetComponent<MonsterInformation>().speed=oriSpeed;
            if (this.gameObject.GetComponent<SpriteRenderer>().sprite != this.gameObject.GetComponent<MonsterLifeSystem>().hurtImage)
            this.gameObject.GetComponent<SpriteRenderer>().sprite = this.gameObject.GetComponent<MonsterLifeSystem>().oriImage;

        }
        if(time>0)
        {
            this.gameObject.GetComponent<MonsterInformation>().speed *= 0.4f;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = coldSprite;

        }
    }
}
