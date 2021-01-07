using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    public ActiveInventoryItem<Bulb> bulbs;
    public ActiveInventoryItem<Lens> lenses;

    public FOV fov;
    public BeamFOVHandler beamHandler;

    private bool beamEnabled = false;

    public bool on;

    private GameObject enclosure;

    public ScrollMode scrollMode;

    public AudioClip pickupSound;

    public AudioClip switchSound;

    public AudioClip batteryDrained;

    public float battery;
    public float maxBattery;

    public float batteryChargeRate;
    public float flickerThreshold;
    private float flickerTimeDelta;
    private bool flickerOnNext;

    public float minFlickerTimeDelta;
    public float maxFlickerTimeDelta;

    public float minRadiusFactor;
    public float radiusFactorPower;

    public bool infiniteBattery;

    public bool hasScrolled = false;
    public bool hasSwitched = false;
    public bool hasTurnedOff = false;

    private string cheatcode = "";

    public enum ScrollMode
    {
        BULBS, LENSES
    }

    // Start is called before the first frame update
    void Start()
    {
        fov.bulb = bulbs.item;
        fov.lens = lenses.item;
    }

    void setBeam(bool value)
    {
        if (beamEnabled)
        {
            beamHandler.active = value;
        }
        else
        {
            fov.showMesh = value;
        }
    }

    // Update is called once per frame
    void Update()
    {

        
        if (Input.GetMouseButtonDown(1))
        {
            scrollMode = scrollMode == ScrollMode.BULBS ? ScrollMode.LENSES : ScrollMode.BULBS;
            GetComponent<AudioSource>().PlayOneShot(switchSound);
            hasSwitched = true;
        }
        if (Input.GetKeyDown("f"))
        {
            hasTurnedOff = true;
            on = !on;
            setBeam(on);
            GetComponent<AudioSource>().PlayOneShot(switchSound);
        }
        foreach (char c in Input.inputString)
        {
            if (c == 'n')
            {
                if (cheatcode == "kelvi")
                {
                    infiniteBattery = !infiniteBattery;
                }
                cheatcode = "";

            }
            else
            {
                cheatcode += c;
            }
        }



        if (on)
        {
            battery = Math.Max(0, battery - Time.deltaTime * bulbs.item.batteryDrainRate);
        } else
        {
            battery = Math.Min(maxBattery, battery + Time.deltaTime * batteryChargeRate);
            if (battery == maxBattery)
            {
                GetComponent<AudioSource>().Stop();
            } else if (!GetComponent<AudioSource>().isPlaying) {
                GetComponent<AudioSource>().Play();
            }
        }
        if (infiniteBattery)
        {
            battery = maxBattery;
        }
        if (battery <= 0)
        {
            if (on)
            {
                GetComponent<AudioSource>().PlayOneShot(batteryDrained, 0.5f);
            }
            on = false;
            setBeam(false);
        }
        if (on && battery <= flickerThreshold)
        {
            flickerTimeDelta -= Time.deltaTime;
            if (flickerTimeDelta < 0)
            {
                flickerTimeDelta = UnityEngine.Random.Range(0.00f, 1.0f);
                //flickerTimeDelta *= flickerTimeDelta;
                //flickerTimeDelta = 1 - flickerTimeDelta;
                flickerTimeDelta = flickerTimeDelta * (maxFlickerTimeDelta - minFlickerTimeDelta) + minFlickerTimeDelta;
                setBeam(flickerOnNext);
                flickerOnNext = !flickerOnNext;
            }
        } else
        {
            flickerOnNext = !on;
        }

        float radiusFactor = battery / maxBattery;
        //radiusFactor = (float)Math.Pow(1 - radiusFactor, radiusFactorPower);
        //fov.radiusFactor = (1- minRadiusFactor) * (1 - radiusFactor) + minRadiusFactor;
        fov.radiusFactor = radiusFactor;

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            hasScrolled = true;
            bool scrollBackwards = scroll < 0;
            switch (scrollMode)
            {
                case ScrollMode.BULBS:
                    if (bulbs.count > 1)
                    {
                        GetComponent<AudioSource>().PlayOneShot(switchSound);
                    }
                    bulbs.rotate(scrollBackwards);
                    beamHandler.bulb = bulbs.item;
                    fov.bulb = bulbs.item;
                    break;
                case ScrollMode.LENSES:
                    if (lenses.count > 1)
                    {
                        GetComponent<AudioSource>().PlayOneShot(switchSound);
                    }
                    lenses.rotate(scrollBackwards);
                    fov.lens = lenses.item;
                    if(lenses.item.name == "Long")
                    {
                        fov.showMesh = false;
                        beamHandler.active = on;
                        beamEnabled = true;
                    } else
                    {
                        beamEnabled = false;
                        fov.showMesh = on;
                        beamHandler.active = false;
                    }
                    break;
            }
        }

        if(Input.GetKeyDown("e"))
        {
            hasScrolled = true;
            switch (scrollMode)
            {
                case ScrollMode.BULBS:
                    if (bulbs.count > 1)
                    {
                        GetComponent<AudioSource>().PlayOneShot(switchSound);
                    }
                    bulbs.rotate(false);
                    beamHandler.bulb = bulbs.item;
                    fov.bulb = bulbs.item;
                    break;
                case ScrollMode.LENSES:
                    if (lenses.count > 1)
                    {
                        GetComponent<AudioSource>().PlayOneShot(switchSound);
                    }
                    lenses.rotate(false);
                    fov.lens = lenses.item;
                    if (lenses.item.name == "Long")
                    {
                        fov.showMesh = false;
                        beamHandler.active = on;
                        beamEnabled = true;
                    }
                    else
                    {
                        beamEnabled = false;
                        fov.showMesh = on;
                        beamHandler.active = false;
                    }
                    break;
            }
        }
        if (Input.GetKeyDown("q"))
        {
            hasScrolled = true;
            switch (scrollMode)
            {
                case ScrollMode.BULBS:
                    if (bulbs.count > 1)
                    {
                        GetComponent<AudioSource>().PlayOneShot(switchSound);
                    }
                    bulbs.rotate(true);
                    beamHandler.bulb = bulbs.item;
                    fov.bulb = bulbs.item;
                    break;
                case ScrollMode.LENSES:
                    if (lenses.count > 1)
                    {
                        GetComponent<AudioSource>().PlayOneShot(switchSound);
                    }
                    lenses.rotate(true);
                    fov.lens = lenses.item;
                    if (lenses.item.name == "Long")
                    {
                        fov.showMesh = false;
                        beamHandler.active = on;
                        beamEnabled = true;
                    }
                    else
                    {
                        beamEnabled = false;
                        fov.showMesh = on;
                        beamHandler.active = false;
                    }
                    break;
            }
        }
    }

    public void AddLense(Lens lens)
    {
        GetComponent<AudioSource>().PlayOneShot(pickupSound);
        Lens original = lenses.item;
        lenses.item = lens;
        lenses.item = original;
    }

    public void AddBulb(Bulb bulb)
    {
        GetComponent<AudioSource>().PlayOneShot(pickupSound);
        Bulb original = bulbs.item;
        bulbs.item = bulb;
        bulbs.item = original;
    }

    public void TakeDamage(float damage)
    {
        battery -= damage;
        if (battery < 0)
            battery = 0;
    }
}
