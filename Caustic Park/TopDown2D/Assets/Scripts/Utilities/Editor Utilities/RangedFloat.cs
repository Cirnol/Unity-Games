using UnityEngine;

public class RangedFloat : PropertyAttribute
{
    public RangedFloat(float min, float max)
    {
        minValue = min;
        maxValue = max;
    }
    public float minValue;

    public float maxValue;
}
