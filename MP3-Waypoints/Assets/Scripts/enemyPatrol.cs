using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrol : MonoBehaviour
{
    public GameObject A;
    public GameObject B;
    public GameObject C;
    public GameObject D;
    public GameObject E;
    public GameObject F;

    private float speed;
    private float rotateSpeed;

    public Transform target;
    private GameObject wayPointTarget;

    // Start is called before the first frame update
    void Start()
    {
        speed = 20f;
        rotateSpeed = 0.03f / 60f;
        target = wayPointTarget.transform;
    }

    // Update is called once per frame
    void Update()
    {

        PointAtPosition(target);

        //Vector3 relativePos = target.position - transform.position;

        //// the second argument, upwards, defaults to Vector3.up
        //Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        //transform.rotation = rotation;
    }

    void PointAtPosition(Transform pos)
    {
        Vector3 relativePos = pos.position - transform.position;
        relativePos.Normalize();

        transform.Rotate(relativePos * Time.deltaTime * rotateSpeed, Space.World);
    }
}
