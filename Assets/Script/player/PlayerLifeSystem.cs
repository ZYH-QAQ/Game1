using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLifeSystem : MonoBehaviour
{
    public float life = 100f;
    public Sprite hurtImage;
    public Sprite oriImage;
    private bool judgeHurt;
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {

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
        if (life <= 0)
        {
            Debug.Log("game over");
            SceneManager.LoadScene(2);
        }

        if (life > 100)
        {
            life = 100;
        }

    }

    public void HitPlayer(float damage)
    {
        judgeHurt = true;
        life -= damage;
    }
}
