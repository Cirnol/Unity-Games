using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraStatus : MonoBehaviour
{
    public Camera watchedCamera;
    public string prefix;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string status = watchedCamera.gameObject.activeInHierarchy ? "Enabled" : "Disabled";
        GetComponent<Text>().text = prefix + status;
    }
}
