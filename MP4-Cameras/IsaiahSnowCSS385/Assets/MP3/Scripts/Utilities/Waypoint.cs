using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public float shakeFrequency;
    [SerializeField] private Globals variables;
    Vector3 startPos;
    Renderer render;
    private ShakePosition shakePosition;
    private Vector2 shakeMagnitude;
    private float shakeDuration;
    private Vector3 origin;
    private bool shaking = false;


    void Start()
    {
        origin = startPos = transform.position;
        render = GetComponent<Renderer>();
        shakeMagnitude = new Vector2(0, 0);
        shakeDuration = 0;
        shakePosition = new ShakePosition(shakeFrequency, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            handleCollision();
            Destroy(collision.gameObject);
        }
    }

    private void handleCollision()
    {
        //Gives the waypoint to the waypoint camera
        variables.waypointCam.SetWaypoint(this, false);
        shaking = true;

        Color color = render.material.color;
        color.a -= .25f;
        shakeMagnitude += new Vector2(1, 1);
        shakeDuration += 1;
        shakePosition.SetShakeParameters(shakeFrequency, shakeDuration);
        shakePosition.SetShakeMagnitude(shakeMagnitude, origin);
        if (color.a <= 0)
        {
            handleReposition();
            color.a = 1;
        }
        render.material.color = color;
    }

    private void handleReposition()
    {
        int x = Random.Range(-1, 2);
        int y = Random.Range(-1, 2);

        Vector3 newPos = startPos;

        newPos.x += x * 15;
        newPos.y += y * 15;

        transform.position = origin = newPos;
        shakeMagnitude = new Vector2(0, 0);
        shakeDuration = 0;
        shakePosition.SetShakeParameters(shakeFrequency, shakeDuration);
        shakePosition.SetShakeMagnitude(shakeMagnitude, origin);
    }
    private void Update()
    {
        if (!shakePosition.ShakeDone())
        {
            transform.position = shakePosition.UpdateShake();
        }
        else
        {
            if (shaking)
            {
                //Clears the waypoint
                variables.waypointCam.SetWaypoint(this, true);
                shaking = false;
            }
        }
    }
}
