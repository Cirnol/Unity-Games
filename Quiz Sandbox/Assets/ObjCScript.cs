using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static instanceCount;

public class ObjCScript : MonoBehaviour
{
    GameObject aObject;
    ObjBScript aScript;

    // Start is called before the first frame update
    void Start()
    {
        countC += 1;
        aObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        aObject.AddComponent<ObjBScript>();
        aScript = GameObject.Find("Obj-B").GetComponent<ObjBScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
