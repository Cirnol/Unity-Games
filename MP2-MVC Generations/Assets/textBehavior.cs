using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;
using static selectingScript;

public class textBehavior : MonoBehaviour
{
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
        
    }

    // Update is called once per frame
    void Update()
    {
        if(selectedObj != null)
        {
            thisText = headText.GetComponent<Text>();
            thisText.text = "Selected:" + selectedObj.name;
        }
        else
        {
            thisText = headText.GetComponent<Text>();
            thisText.text = "Selected: None";
        }

        thisText = XSliderText.GetComponent<Text>();
        thisText.text = "X                  " + sliderX.value;
        thisText = YSliderText.GetComponent<Text>();
        thisText.text = "X                  " + sliderY.value;
        thisText = ZSliderText.GetComponent<Text>();
        thisText.text = "X                  " + sliderZ.value;

    }
}
