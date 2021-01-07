using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Hero hero;

    public float HP { get { return hero.HP; } }
    public float maxHP { get { return hero.maxHP; } }
    public float battery { get { return flashlightController.battery; } }
    public float maxBattery { get { return flashlightController.maxBattery; } }

    public FlashlightController flashlightController;

    public float painIndicatorFadeTime;

    public Color painIndicator;

    private bool hit = false;

    public GameObject deathOverlay;

    public GameObject godModeIndicator;

    public GameObject infiniteBatteryIndicator;

    private float damage;

    private bool powerDrain = false;

    float r = 0;
    float g = 0;
    float b = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hit)
        {
            if(powerDrain)
            {
                powerDrain = false;
                r = 0.705882353f;
                g = 0.666666667f;
                b = 0.196078431f;
            } else
            {
                r = 0.705882353f;
                g = 0.196078431f;
                b = 0.196078431f;
            }
            hit = false;
            painIndicator.a = 1.0f;
        }
        painIndicator = new Color(r,g,b, Mathf.Max(0f, painIndicator.a - Time.deltaTime / painIndicatorFadeTime));

        godModeIndicator.SetActive(hero.godMode);
        infiniteBatteryIndicator.SetActive(flashlightController.infiniteBattery);
    }

    public void playerHit(float damage)
    {
        if (damage == 0)
        {
            powerDrain = true;
        }
        hit = true;

    }

    public void die()
    {
        deathOverlay.SetActive(true);
    }
}
