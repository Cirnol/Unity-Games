using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class sliderBehavior : MonoBehaviour
{
    public GameObject selectedObj;

    public GameObject cameraObj;
    private ToggleGroup myToggleGroup;
    public Toggle translateTog;
    public Toggle rotateTog;
    public Toggle scaleTog;
    private Toggle theActiveToggle;

    public Slider sliderX;
    public Slider sliderY;
    public Slider sliderZ;

    private float sliderEchoX;
    private float sliderEchoY;
    private float sliderEchoZ;

    private Vector3 move;
    private Quaternion spin;

    private GameObject current;
    private bool transMatching;
    private bool scaleMatching;
    private bool rotateMatching;

    // Start is called before the first frame update
    void Start()
    {
        translateTog = GetComponent<Toggle>();
        rotateTog = GetComponent<Toggle>();
        scaleTog = GetComponent<Toggle>();
        myToggleGroup = cameraObj.GetComponent<ToggleGroup>();

        current = null;
    }

    // Update is called once per frame
    void Update()
    {
        theActiveToggle = myToggleGroup.ActiveToggles().FirstOrDefault();

        theActiveToggle.onValueChanged.AddListener(delegate {
            ToggleValueChanged(theActiveToggle);
        });

        // TRANSLATE
        if (theActiveToggle.gameObject.name == "TToggle")
        {
            // Initialize the slider min and max
            sliderX.minValue = -17;
            sliderY.minValue = 0;
            sliderZ.minValue = -5;
            sliderX.maxValue = 17;
            sliderY.maxValue = 17;
            sliderZ.maxValue = 24;

            if(!transMatching)
                loadSliderValues(theActiveToggle.gameObject.name);

            if (selectedObj == current && selectedObj != null)
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
            }
            else
            {
                transMatching = false;
                current = selectedObj;
            }
        }

        // SCALING
        if (theActiveToggle.gameObject.name == "SToggle")
        {
            // Initialize the slider min and max
            sliderX.minValue = .1f;
            sliderY.minValue = .1f;
            sliderZ.minValue = .1f;
            sliderX.maxValue = 20;
            sliderY.maxValue = 20;
            sliderZ.maxValue = 20;

            if (!scaleMatching)
                loadSliderValues(theActiveToggle.gameObject.name);

            if (selectedObj == current && selectedObj != null)
            {
                // X Scale
                sliderEchoX = sliderX.value;
                move = new Vector3(sliderEchoX, selectedObj.transform.localScale.y, selectedObj.transform.localScale.z);
                selectedObj.transform.localScale = move;
                sliderX.value = sliderEchoX;
                //Y Scale
                sliderEchoY = sliderY.value;
                move = new Vector3(selectedObj.transform.localScale.x, sliderEchoY, selectedObj.transform.localScale.z);
                selectedObj.transform.localScale = move;
                sliderY.value = sliderEchoY;
                // Z Scale
                sliderEchoZ = sliderZ.value;
                move = new Vector3(selectedObj.transform.localScale.x, selectedObj.transform.localScale.y, sliderEchoZ);
                selectedObj.transform.localScale = move;
                sliderZ.value = sliderEchoZ;
            }
            else
            {
                scaleMatching = false;
                current = selectedObj;
            }
        }

        if (theActiveToggle.gameObject.name == "RToggle")
        {
            // Initialize the slider min and max
            sliderX.minValue = 0;
            sliderY.minValue = 0;
            sliderZ.minValue = 0;
            sliderX.maxValue = 359;
            sliderY.maxValue = 359;
            sliderZ.maxValue = 359;

            if (!rotateMatching)
                loadSliderValues(theActiveToggle.gameObject.name);

            if (selectedObj == current && selectedObj != null)
            {
                sliderEchoX = sliderX.value;
                sliderEchoY = sliderY.value;
                sliderEchoZ = sliderZ.value;

                spin = Quaternion.Euler(sliderEchoX, sliderEchoY, sliderEchoZ);
                selectedObj.transform.localRotation = spin;

                sliderX.value = sliderEchoX;
                sliderY.value = sliderEchoY;
                sliderZ.value = sliderEchoZ;
            }
            else
            {
                rotateMatching = false;
                current = selectedObj;
            }
        }
    }

    void loadSliderValues(string name)
    {
        if(name == "TToggle")
        {
            if (selectedObj != null)
            {
                // Change slider values to match the objects position
                sliderX.value = selectedObj.transform.localPosition.x;
                sliderY.value = selectedObj.transform.localPosition.y;
                sliderZ.value = selectedObj.transform.localPosition.z;
            }
            else
            {
                sliderX.value = 0;
                sliderY.value = 0;
                sliderZ.value = 0;
            }

            transMatching = true;
        }

        if (name == "SToggle")
        {
            if (selectedObj != null)
            {
                // Change slider values to match the objects scale
                sliderX.value = selectedObj.transform.localScale.x;
                sliderY.value = selectedObj.transform.localScale.y;
                sliderZ.value = selectedObj.transform.localScale.z;
            }
            else
            {
                sliderX.value = 1;
                sliderY.value = 1;
                sliderZ.value = 1;
            }

            scaleMatching = true;
        }

        if (name == "RToggle")
        {
            if (selectedObj != null)
            {
                // Change slider values to match the objects scale
                sliderX.value = selectedObj.transform.localEulerAngles.x;
                sliderY.value = selectedObj.transform.localEulerAngles.y;
                sliderZ.value = selectedObj.transform.localEulerAngles.z;
            }
            else
            {
                sliderX.value = 0;
                sliderY.value = 0;
                sliderZ.value = 0;
            }

            rotateMatching = true;
        }
    }
    void ToggleValueChanged(Toggle change)
    {
        transMatching = false;
        scaleMatching = false;
        rotateMatching = false;
    }
}