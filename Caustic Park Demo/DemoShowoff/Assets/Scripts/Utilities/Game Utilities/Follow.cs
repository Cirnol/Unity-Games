using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] private PlayerMovement follow;
    private Rigidbody2D rb;
    private float z;

    private void Awake()
    {
        rb = follow.GetComponent<Rigidbody2D>();
        z = transform.position.z;
    }

    void FixedUpdate()
    {
        Vector3 pos = follow.position;
        pos.z = z;
        transform.position = Vector3.Lerp(transform.position, pos, 1f);
    }


}
