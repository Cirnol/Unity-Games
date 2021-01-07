using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Bulb", order = 1)]
public class Bulb : ScriptableObject
{
    public float intensity;

    public Material material;

    public enum Power
    {
        NONE, INVISIBLE_INK, HEAT, XRAY
    }

    public Power power;

    public float batteryDrainRate;
}
