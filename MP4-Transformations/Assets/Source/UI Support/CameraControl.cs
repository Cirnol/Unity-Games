using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour
{
    public GameObject selectedObj;

    // Assign these in Unity
    public Slider sliderX;
    public Slider sliderY;
    public Slider sliderZ;

    private float sliderEchoX;
    private float sliderEchoY;
    private float sliderEchoZ;

    private Vector3 move;

    Text thisText;

    public GameObject XSliderText;
    public GameObject YSliderText;
    public GameObject ZSliderText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // X Transform
        sliderEchoX = sliderX.value;
        move = new Vector3(sliderEchoX, selectedObj.transform.localPosition.y, selectedObj.transform.localPosition.z);
        selectedObj.transform.localPosition = move;
        sliderX.value = sliderEchoX;
        // Y Transform
        sliderEchoY = sliderY.value;
        move = new Vector3(selectedObj.transform.localPosition.x, sliderEchoY, selectedObj.transform.localPosition.z);
        selectedObj.transform.localPosition = move;
        sliderY.value = sliderEchoY;
        // Z Transform
        sliderEchoZ = sliderZ.value;
        move = new Vector3(selectedObj.transform.localPosition.x, selectedObj.transform.localPosition.y, sliderEchoZ);
        selectedObj.transform.localPosition = move;
        sliderZ.value = sliderEchoZ;


        // Update Echo Values
        float x = sliderX.value;
        float y = sliderY.value;
        float z = sliderZ.value;

        double xv = System.Math.Round(x, 2);
        double yv = System.Math.Round(y, 2);
        double zv = System.Math.Round(z, 2);

        thisText = XSliderText.GetComponent<Text>();
        thisText.text = "" + xv;
        thisText = YSliderText.GetComponent<Text>();
        thisText.text = "" + yv;
        thisText = ZSliderText.GetComponent<Text>();
        thisText.text = "" + zv;
    }
}
