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
        thisText = XSliderText.GetComponent<Text>();
        thisText.text = "X            " + sliderX.value;
        thisText = YSliderText.GetComponent<Text>();
        thisText.text = "Y            " + sliderY.value;
        thisText = ZSliderText.GetComponent<Text>();
        thisText.text = "Z            " + sliderZ.value;
    }
}
