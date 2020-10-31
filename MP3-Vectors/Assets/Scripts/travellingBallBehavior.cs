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


        // Third Try
        

        // the plane and its normal
        Vector3 n = -barrier.transform.forward;
        Vector3 center = barrier.transform.localPosition;
        Vector3 pt = center + kNormalSize * n;
        float d = Vector3.Dot(n, center);

        float h = Vector3.Dot(this.transform.localPosition, n) - d;
        FlatShadow.transform.localPosition = this.transform.localPosition - (n * h);
        FlatShadow.transform.forward = n;
        FlatShadow.GetComponent<MeshRenderer>().enabled = true;
        //float s = h * 0.50f;
        //if (s < 0)
        //    s = 0.5f;
        //FlatShadow.transform.localScale = new Vector3(s, s, s);
        Debug.DrawLine(shadow.transform.localPosition, this.transform.localPosition, Color.black);

        Debug.DrawLine(center, pt, Color.black);







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
        //Vector3 centerBarrier = barrier.transform.position; // The center of the barrier
        //Vector3 centerSphere = this.transform.localPosition; // The center of the sphere
        //Vector3 V = (centerSphere - centerBarrier); // Vector from sphere to center of barrier
        //float d = V.magnitude; // Distance of that vector V
        //V.Normalize(); // Make V be a unit vector

        //Vector3 n = -barrier.transform.forward; // The normal of the barrier
        //float posCheck = Vector3.Dot(n, V); // Needed to check if the sphere is behind the plane

        //if (posCheck < 0)
        //{
        //    move = 2 * (Vector3.Dot(-move, n)) * n - (-move); // Reflection formula
        //}

    }




}

