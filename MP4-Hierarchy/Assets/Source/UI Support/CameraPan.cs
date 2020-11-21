using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    Vector3 delta;
    Vector3 mouseDownPos;
    public Camera cameraObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Panning
        if (Input.GetMouseButtonDown(1))
        {
            mouseDownPos = Input.mousePosition;
            delta = Vector3.zero;
        }
        if (Input.GetMouseButton(1))
        {
            delta = mouseDownPos - Input.mousePosition;
            Vector3 move = new Vector3(delta.x, delta.y, delta.z);
            //Debug.Log(delta);
            transform.Translate(delta);
            cameraObj.transform.Translate(delta);
            //cameraObj.transform.localPosition = move;
            //Debug.Log("TargetPos:" + target.transform.position);

            //transform.localPosition = move;
            mouseDownPos = Input.mousePosition;


        }
    }
}
