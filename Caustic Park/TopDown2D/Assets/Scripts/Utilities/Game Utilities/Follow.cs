using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] private GameObject follow;
    private float z;

    private void Awake()
    {
        z = transform.position.z;
    }

    void Update()
    {
        Vector3 pos = Vector3.Lerp(transform.position, follow.transform.position, 1f);
        pos.z = z;
        transform.position = pos;
    }
}
