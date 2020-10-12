using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static instanceCount;

public class ObjDScript : MonoBehaviour
{
    GameObject aObject;
    ObjAScript aScript;

    // Start is called before the first frame update
    void Start()
    {
        countD += 1;
        aObject = GameObject.Find("Obj-A");
        aScript = aObject.GetComponent<ObjAScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
