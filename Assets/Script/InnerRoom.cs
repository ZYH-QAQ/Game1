using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerRoom : MonoBehaviour
{
    public bool judgePlayerIn;
    public LayerMask playerLayer;
    // Start is called before the first frame update
    void Start()
    {
        judgePlayerIn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapArea(new Vector2(this.gameObject.transform.parent.position.x + 8, this.gameObject.transform.parent.position.y + 4), new Vector2(this.gameObject.transform.parent.position.x - 8, this.gameObject.transform.parent.position.y - 4), playerLayer))
            judgePlayerIn = true;

    }


}
