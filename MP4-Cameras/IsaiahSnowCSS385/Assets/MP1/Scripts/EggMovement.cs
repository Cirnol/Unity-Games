using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggMovement : MonoBehaviour
{

    public bool right;
    public bool up;

    private ParticleSystem particles;

    public bool isPlaying = false;
    public bool isRotating = false;

    public float seconds = 1.5f;

    private int y = 1;
    private int x = 1;

    private float angle = 0;

    private int minX = 1;
    private int maxX = 50;
    private int minY = 1;
    private int maxY = 50;
    private int minRot = 0;
    private int maxRot = 360;

    private void Start()
    {
        particles = GetComponent<ParticleSystem>();

        if(particles)
        {
            particles.Stop();
        }

        if(!right)
        {
            x = -1;
            minX = -1;
            maxX = -50;
            maxRot = -360;
        }
        if(!up)
        {
            y = -1;
            minY = -1;
            maxY = -50;
        }
    }

    private void Update()
    {
        UpdatePosition();
        UpdateScale();
        UpdateRotation();
        UpdateParticles();
    }

    public float GetValue()
    {
        float xPos = transform.position.x;
        float value = (xPos - 1) / 49f;
        return value;
    }

    private void UpdatePosition()
    {
        float delta = Input.GetAxis("Vertical");

        float newX = transform.position.x + (delta * Time.deltaTime * x * 49/ seconds);
        float newY = transform.position.y + (delta * Time.deltaTime * y * 49/ seconds);

        if (Mathf.Abs(newX) < Mathf.Abs(minX))
        {
            newX = minX;
        }
        else if (Mathf.Abs(newX) > Mathf.Abs(maxX))
        {
            newX = maxX;
        }

        if (Mathf.Abs(newY) < Mathf.Abs(minY))
        {
            newY = minY;
        }
        else if (Mathf.Abs(newY) > Mathf.Abs(maxY))
        {
            newY = maxY;
        }

        transform.position = new Vector3(newX, newY);
    }

    private void UpdateScale()
    {
        float delta = Input.GetAxis("Vertical") * Time.deltaTime * 5/ seconds;

        Vector3 size = new Vector3(delta, delta, delta);
        Vector3 newScale = transform.localScale + size;

        if(newScale.x < 1)
        {
            newScale = new Vector3(1, 1, 1);
        }

        else if(newScale.x > 6)
        {
            newScale = new Vector3(6, 6, 6);
        }

        transform.localScale = newScale;
    }

    private void UpdateRotation()
    {
        float delta = Input.GetAxis("Vertical") * Time.deltaTime * 360/ seconds * x;

        angle += delta;
        if(right && angle < 0)
        {
            angle = 0;
        }
        else if (!right && angle > 0)
        {
            angle = 0;
        }

        if (Mathf.Abs(angle) > Mathf.Abs(maxRot))
        {
            angle = maxRot;
        }

        Vector3 newRot = transform.rotation.eulerAngles;
        newRot.z = angle;

        if(angle == transform.eulerAngles.z || angle == maxRot || delta == 0)
        {
            isRotating = false;
        }
        else
        {
            isRotating = true;
        }

        transform.eulerAngles = newRot;
    }

    private void UpdateParticles()
    {
        if(!particles)
        {
            return;
        }

        float input = Input.GetAxis("Vertical");

        if(input != 0 && !isPlaying)
        {
            isPlaying = true;
            particles.Play();
        }

        else if(input == 0 && isPlaying)
        {
            isPlaying = false;
            particles.Stop();
        }
    }
}
