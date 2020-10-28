using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrierSliders : MonoBehaviour
{
    public GameObject barrier;
    public GameObject normal;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //bX = barrier.transform.position.x;
        //bY = barrier.transform.position.y;
        //bZ = barrier.transform.position.z;

        //normal.transform.localPosition = new Vector3(bX, bY, bZ);

        // Barrier Normal
        normal.transform.up = -barrier.transform.forward;
        normal.transform.localPosition = barrier.transform.localPosition + 5f * normal.transform.up;
    }
}
