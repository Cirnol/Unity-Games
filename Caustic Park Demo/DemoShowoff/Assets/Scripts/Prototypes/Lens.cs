using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Lens", order = 1)]
public class Lens : ScriptableObject
{
    public float fov;

    public float radius;
}
