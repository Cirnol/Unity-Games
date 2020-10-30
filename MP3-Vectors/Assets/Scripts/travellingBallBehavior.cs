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

        // Reflection
        Vector3 V = (this.transform.position - barrier.transform.position);
        V.Normalize();

        Vector3 n = -barrier.transform.forward;
        Vector3 center = barrier.transform.localPosition;
        float d = Vector3.Dot(n, center);

        float isBehindBarrier = Vector3.Dot(n, V);

        if(isBehindBarrier < 0)
        {
            move = 2 * (Vector3.Dot(-move, n)) * n - (-move);
        }
    }




}

