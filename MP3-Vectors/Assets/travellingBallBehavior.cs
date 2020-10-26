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

    // Start is called before the first frame update
    void Start()
    {
        offset.Normalize();
        move = new Vector3(offset.x, offset.y, offset.z) * Time.deltaTime * setSpeed;
        health = lifeSpan;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(move);

        health -= Time.deltaTime;
        if (health <= 0)
            Destroy(gameObject);
    }
}
