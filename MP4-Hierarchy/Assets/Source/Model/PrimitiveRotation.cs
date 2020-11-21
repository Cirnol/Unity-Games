using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PrimitiveRotation : MonoBehaviour {

    bool rotateUp;

    void Start() 
    {
        rotateUp = true;
    }

    void Update() 
    {
        if(rotateUp)
            transform.localRotation = Quaternion.AngleAxis(1f, -Vector3.forward) * transform.localRotation;
        else
            transform.localRotation = Quaternion.AngleAxis(1f, Vector3.forward) * transform.localRotation;

        // Obtain Rotation Z value and convert to 360 degrees
        float result = gameObject.transform.rotation.eulerAngles.z - Mathf.CeilToInt(gameObject.transform.rotation.eulerAngles.z / 360f) * 360f;
        if (result < 0)
        {
            result += 360f;
        }
        // Obtained from https://answers.unity.com/questions/1427258/get-an-eular-angle-between-0-and-360-after-calcula.html

        if (result <= 280 && result > 100)
            rotateUp = false;
        
        if (result >= 80 && result < 100)
            rotateUp = true;
       
    }
}