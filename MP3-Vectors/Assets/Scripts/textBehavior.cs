using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textBehavior : MonoBehaviour
{
    public GameObject selectedObj;

    public GameObject headText;
    public GameObject XSliderText;
    public GameObject YSliderText;
    public GameObject ZSliderText;

    public Slider sliderX;
    public Slider sliderY;
    public Slider sliderZ;

    Text thisText;

    // Start is called before the first frame update
    void Start()
    {
        thisText = headText.GetComponent<Text>();
        thisText.text = "Selected: " + selectedObj.name;
    }

    // Update is called once per frame
    void Update()
    {
        float x = sliderX.value;
        float y = sliderY.value;
        float z = sliderZ.value;

        double xv = System.Math.Round(x, 2);
        double yv = System.Math.Round(y, 2);
        double zv = System.Math.Round(z, 2);

        thisText = XSliderText.GetComponent<Text>();
        thisText.text = "X            " + xv;
        thisText = YSliderText.GetComponent<Text>();
        thisText.text = "Y            " + yv;
        thisText = ZSliderText.GetComponent<Text>();
        thisText.text = "Z            " + zv;
    }
}
