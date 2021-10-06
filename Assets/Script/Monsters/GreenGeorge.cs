using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenGeorge : MonoBehaviour
{
    float life;
    //public GameObject GreenFog;
    // Start is called before the first frame update
    void Start()
    {
        life = this.gameObject.GetComponent<MonsterLifeSystem>().life;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
