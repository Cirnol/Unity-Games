using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintToScreen : MonoBehaviour
{
    public FloatVariable variable;

    private void Awake()
    {
        Debug.Log(variable.value);
    }
}
