﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkLightOff : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }
}
