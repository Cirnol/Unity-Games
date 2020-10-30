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

    float kNormalSize = 10f;
    float kVerySmall = 0.0001f; // let's avoid this

    // Start is called before the first frame update
    void Start()
    {
        offset.Normalize();
        move = new Vector3(offset.x, offset.y, offset.z) * Time.deltaTime * setSpeed;
        health = lifeSpan;

        barrier = GameObject.Find("Barrier");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(move);

        health -= Time.deltaTime;
        if (health <= 0)
            Destroy(gameObject);

        //Reflection
        Vector3 V = (this.transform.position - barrier.transform.position);
        float d = V.magnitude;
        V.Normalize();

        Vector3 n = -barrier.transform.forward;
        Vector3 center = barrier.transform.localPosition;

        float denom = Vector3.Dot(n, move);
        float posCheck = Vector3.Dot(n, V);

        if (posCheck < 0 && (denom < 0.5 || denom > 0.01))
        {
            move = 2 * (Vector3.Dot(-move, n)) * n - (-move);
        }
    }




}

