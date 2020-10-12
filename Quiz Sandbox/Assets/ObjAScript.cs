using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static instanceCount;

public class ObjAScript : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        countA += 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += Vector3.right * 0.1f;
    }
}
