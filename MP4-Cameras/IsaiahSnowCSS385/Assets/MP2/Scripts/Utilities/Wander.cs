using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{
    public float MaxAngle = 90;
    public float MaxSpeed = 60;
    private Vector3 movement;
    private float angle;

    void Awake()
    {

        if(GetComponent<ScreenWrap>() == null)
        {
            gameObject.AddComponent<ScreenWrap>();
        }

        Vector2 vel = new Vector2(Random.Range(-MaxSpeed, MaxSpeed), Random.Range(-MaxSpeed, MaxSpeed));
        movement = vel;
        angle = Random.Range(-MaxAngle, MaxAngle);
    }

    private void Update()
    {
        transform.Translate(movement * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.forward, angle * Time.deltaTime);
    }
}
