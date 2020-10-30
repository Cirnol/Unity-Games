using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Spawner : ScriptableObject
{
    public GameObject toSpawn;

    public GameObject Spawn(Vector3 position, Quaternion rotation)
    {
        return Instantiate(toSpawn, position, rotation);
    }
}
