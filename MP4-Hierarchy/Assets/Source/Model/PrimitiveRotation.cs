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


        float result = gameObject.transform.rotation.eulerAngles.z - Mathf.CeilToInt(gameObject.transform.rotation.eulerAngles.z / 360f) * 360f;
        if (result < 0)
        {
            result += 360f;
        }

        Debug.Log(result);

        

        if (result <= 280 && result > 100)
            rotateUp = false;
        
        if (result >= 80 && result < 100)
            rotateUp = true;
        


        //transform.localRotation = Quaternion.AngleAxis(45 * Mathf.Sin(Time.realtimeSinceStartup), transform.forward) * transform.localRotation;
    }
}