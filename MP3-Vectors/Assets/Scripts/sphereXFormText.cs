using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sphereXFormText : MonoBehaviour
{
    public GameObject intText;
    public GameObject spdText;
    public GameObject lifeText;

    public Slider interval;
    public Slider speed;
    public Slider life;

    Text thisText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float i = interval.value;
        float s = speed.value;
        float l = life.value;

        double iv = System.Math.Round(i, 2);
        double sv = System.Math.Round(s, 2);
        double lv = System.Math.Round(l, 2);

        thisText = intText.GetComponent<Text>();
        thisText.text = "Interval            " + iv;
        thisText = spdText.GetComponent<Text>();
        thisText.text = "Speed            " + sv;
        thisText = lifeText.GetComponent<Text>();
        thisText.text = "Life (Sec)            " + lv;
    }
}
