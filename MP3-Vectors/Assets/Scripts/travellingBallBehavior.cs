using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using static aimLineMath;
using static ballSliders;

public class travellingBallBehavior : MonoBehaviour
{
    Vector3 move;
    float health;

    public GameObject barrier;
    public GameObject radiusSphere;
    public GameObject shadow;
    private GameObject FlatShadow;

    float kNormalSize = 10f;
    float kVerySmall = 0.0001f; // let's avoid this

    // Start is called before the first frame update
    void Start()
    {
        offset.Normalize();
        move = new Vector3(offset.x, offset.y, offset.z) * Time.deltaTime * setSpeed;
        health = lifeSpan;

        barrier = GameObject.Find("Barrier");
        radiusSphere = GameObject.Find("Radius");

        //shadow = GameObject.Find("Shadow");
        FlatShadow = Instantiate(shadow, new Vector3(1, 3, 9), Quaternion.identity);
        FlatShadow.GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(move);

        health -= Time.deltaTime;
        if (health <= 0)
        {
            Destroy(gameObject);
            Destroy(FlatShadow);
        }

        Vector3 centerSphere = this.transform.localPosition; // The center of the sphere
        Vector3 center = barrier.transform.localPosition; // The center of the barrier
        Vector3 n = -barrier.transform.forward; // Normal Vector of Barrier
        Vector3 V = (centerSphere - center); // Vector from sphere to center of barrier

        float distance = V.magnitude; // Distance of the vector V
        n.Normalize();
        V.Normalize(); // Make V be a unit vector
        Vector3 pt = center + kNormalSize * n;

        float d = Vector3.Dot(n, center);
        float h = Vector3.Dot(centerSphere, n) - d;
        Vector3 intersectionPoint = centerSphere - (n * h); // Predicted point of intersection
        FlatShadow.transform.localPosition = intersectionPoint; // Move the shadows to the intesection point
        FlatShadow.transform.forward = n; // Orient the shadows so they're flat against the plane.

        float posCheck = Vector3.Dot(n, V); // Needed to check if the sphere is behind the plane
        float dirCheck = Vector3.Dot(n, move); // Needed to see if the sphere direction is opposite the normal
        float sphereRadius = transform.localScale.x * 0.5f;
        float barrierRadius = barrier.transform.localScale.x * 0.5f;

        float distanceIntersectCenter = (intersectionPoint - center).magnitude;
        float distanceIntersectSphere = (intersectionPoint - centerSphere).magnitude;

        if (distanceIntersectCenter < (barrierRadius)) // Check if sphere will collide within the radius
        {
            if(dirCheck < 0) // Check if the direction of sphere and normal are opposite
            {
                FlatShadow.GetComponent<MeshRenderer>().enabled = true;

                if (posCheck < 0) // Check if sphere is behind the plane
                {
                    if (distanceIntersectSphere < sphereRadius) // Check if the sphere is close to the barrier
                    {
                        move = 2 * (Vector3.Dot(-move, n)) * n - (-move); // Reflection formula 
                    }
                }
                else
                {
                    //FlatShadow.GetComponent<MeshRenderer>().enabled = false;
                }
            }
            else
            {
                //FlatShadow.GetComponent<MeshRenderer>().enabled = false;
            }
        }
        else
        {
            FlatShadow.GetComponent<MeshRenderer>().enabled = false;
        }

        

        






        // Second try
        //float r = 1.5f;

            //Vector3 barrierCenter = barrier.transform.position; // Center of barrier
            //Vector3 barrierDirection = barrier.transform.up; // Length of the barrier
            //Vector3 sphereCenter = this.transform.position; // Center of sphere
            //Vector3 spheretoBarrier = sphereCenter - barrierCenter; // V
            //float angle = Vector3.Dot(spheretoBarrier, barrierDirection);
            //Vector3 projectedVector = angle * barrierDirection;
            //Vector3 projectedPos = projectedVector + barrierCenter;
            //Vector3 barrierNormal = (sphereCenter - projectedPos).normalized;
            //Vector3 point_of_impact = projectedPos + barrierNormal * r;

            //Instantiate(shadow, point_of_impact, Quaternion.identity);




            //// First try
            ////Reflection







    }




}

