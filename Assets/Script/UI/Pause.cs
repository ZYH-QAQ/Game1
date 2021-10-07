using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject panel;
    bool i=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!i&&Input.GetKeyDown(KeyCode.Escape))
        {
            panel.SetActive(true);
            i = true;
            Time.timeScale = 0;
        }
        else if(i&& Input.GetKeyDown(KeyCode.Escape))
        {
            i = false;
            Time.timeScale = 1;
            panel.SetActive(false);

        }
    }
}
