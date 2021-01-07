using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryPanel: MonoBehaviour
{
    public HUD hud;
    public Text text;
    public Slider slider;
    public Image flashlightIcon;

    public Image flashOn;

    // Start is called before the first frame update
    void Start()
    {
        slider.minValue = 0;
        flashOn.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = (int)hud.battery + "/" + hud.maxBattery;
        slider.maxValue = hud.maxBattery;
        slider.value = hud.battery;
        Color c = flashlightIcon.color;
        c.a = hud.flashlightController.on ? 1.0f : 0.25f;
        flashlightIcon.color = c;

        if(!hud.flashlightController.on)
        {
            flashOn.enabled = false;
        }
        else
            flashOn.enabled = true;
    }
}
