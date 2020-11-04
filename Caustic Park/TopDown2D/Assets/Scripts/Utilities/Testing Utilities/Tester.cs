using System.Collections;
using System.Collections.Generic;
using UnityEditor.Android;
using UnityEngine;

public class Tester : MonoBehaviour
{
    public Health health;
    public PowerupEffect effect;

    public bool test = false;

    private void Update()
    {
        if(test)
        {
            test = false;
            effect.Apply(gameObject);
        }
    }
}
