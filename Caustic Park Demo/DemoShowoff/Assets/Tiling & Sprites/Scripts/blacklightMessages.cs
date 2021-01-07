using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blacklightMessages : MonoBehaviour
{
    public TheWorld theWorld = null;
    private bool isSeen = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (theWorld.getBulb().name == "Blacklight")
        {
            GetComponent<PolygonCollider2D>().enabled = true;
            if(isSeen)
            {
                GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<PolygonCollider2D>().enabled = false;
        }
    }

    public void Seen(bool _isSeen)
    {
        isSeen = _isSeen;
    }
}
