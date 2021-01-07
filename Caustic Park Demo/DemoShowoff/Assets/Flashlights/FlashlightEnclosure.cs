using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightEnclosure : MonoBehaviour
{
    public bool swappableLenses;

    public Bulb bulb;

    private Lens mLens;
    public Lens lens {
        get { return mLens; }
        set { if (swappableLenses) { mLens = value; } }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
