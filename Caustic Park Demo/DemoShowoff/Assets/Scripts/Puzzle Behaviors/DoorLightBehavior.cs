using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLightBehavior : MonoBehaviour
{
    public Sprite offSprite;
    public Sprite onSprite;
    // Start is called before the first frame update
    public void turnOn()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = onSprite;
    }

    public void turnOff()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = offSprite;
    }
}
