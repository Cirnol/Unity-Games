using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPanel : MonoBehaviour
{
    public HUD hud;
    public Text text;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider.minValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = hud.HP + "/" + hud.maxHP;
        slider.maxValue = hud.maxHP;
        slider.value = hud.HP;
    }
}
