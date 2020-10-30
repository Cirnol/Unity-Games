﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    public float deltaAngle;

    void Update()
    {
        float delta = Input.GetAxis("Horizontal") * Time.deltaTime * deltaAngle;

        transform.Rotate(new Vector3(0, 0, 1), -delta);
    }
}
