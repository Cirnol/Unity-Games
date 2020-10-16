using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static selectingScript;

public class sliderBehavior : MonoBehaviour
{
    public Slider sliderX;
    public Slider sliderY;
    public Slider sliderZ;

    private float sliderEchoX;
    private float sliderEchoY;
    private float sliderEchoZ;

    private Vector3 move;
    private GameObject current;

    // Start is called before the first frame update
    void Start()
    {
        current = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (selectedObj != current)
        {
            if (selectedObj != null)
            {
                sliderX.value = selectedObj.transform.localPosition.x;
                sliderY.value = selectedObj.transform.localPosition.y;
                sliderZ.value = selectedObj.transform.localPosition.z;
                current = selectedObj;
            }
            else
                current = null;
        }

        if(selectedObj != null)
        {
            // X Transform
            sliderEchoX = sliderX.value;
            move = new Vector3(sliderEchoX, selectedObj.transform.localPosition.y, selectedObj.transform.localPosition.z);
            selectedObj.transform.localPosition = move;
            sliderX.value = sliderEchoX;
            //Y Transform
            sliderEchoY = sliderY.value;
            move = new Vector3(selectedObj.transform.localPosition.x, sliderEchoY, selectedObj.transform.localPosition.z);
            selectedObj.transform.localPosition = move;
            sliderY.value = sliderEchoY;
            // Z Transform
            sliderEchoZ = sliderZ.value;
            move = new Vector3(selectedObj.transform.localPosition.x, selectedObj.transform.localPosition.y, sliderEchoZ);
            selectedObj.transform.localPosition = move;
            sliderZ.value = sliderEchoZ;
        }
        else
        {
            sliderX.value = 0;
            sliderEchoX = 0;

            sliderY.value = 0;
            sliderEchoY = 0;

            sliderZ.value = 0;
            sliderEchoZ = 0;
        }




        //sliderEchoX = selectedObj.transform.localPosition.x;


    }
}
