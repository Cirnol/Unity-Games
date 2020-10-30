using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggState : MonoBehaviour
{
    private float timer = 0.0f;
    private float timeToStopLerping = 2.0f;

    void Start()
    {
        gameObject.GetComponent<Animator>().Play("Egg");
        // transform.GetComponent<SpriteRenderer>().color = Color.red;
        //stationary, wait for hit
    }

}
