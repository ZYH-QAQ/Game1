using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public Text win;
    public bool judgeWin;
    public GameObject wintext;
    float time=3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(judgeWin)
        {
            wintext.SetActive(true);
            time -= Time.deltaTime;
        }
        if(time<=0)
        {
            SceneManager.LoadScene(2);
        }
    }
}
