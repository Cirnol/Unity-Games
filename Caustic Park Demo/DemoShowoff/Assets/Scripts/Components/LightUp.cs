using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUp : MonoBehaviour
{
    [SerializeField] private GameObject circle;
    private bool wasLit = false;

    private void Update()
    {
        if(!wasLit)
        {
            circle.SetActive(false);
        }
        else
        {
            wasLit = false;
        }
    }

    public void Light()
    {
        circle.SetActive(true);
        wasLit = true;
    }
}
