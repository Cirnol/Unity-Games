using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashlightBulbIndicator : MonoBehaviour
{
    public HUD hud;
    public Bulb bulb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Color color = GetComponent<Image>().color;
        color.a = 0;
        bool available = hud.flashlightController.bulbs.contains(bulb);
        bool active = hud.flashlightController.bulbs.item == bulb;
        if (available)
        {
            color.a = active ? 1.0f : 0.25f;
        }
        GetComponent<Image>().color = color;
    }
}
