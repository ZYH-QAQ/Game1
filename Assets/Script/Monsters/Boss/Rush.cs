using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rush : MonoBehaviour
{
    private void OnDisable()
    {
        this.GetComponent<MonsterInformation>().speed = 0.5f;

    }
    private void Start()
    {
        
    }
    private void Update()
    {
        this.GetComponent<MonsterInformation>().speed = 7f;

    }
}
