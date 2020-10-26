using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using static aimLineMath;

public class travellingBallBehavior : MonoBehaviour
{
    float setSpeed;
    float lifeSpan;
    Vector3 move;

    // Start is called before the first frame update
    void Start()
    {
        setSpeed = 5f;
        lifeSpan = 10f;

        offset.Normalize();
        move = new Vector3(offset.x, offset.y, offset.z) * Time.deltaTime * setSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(move);

        lifeSpan -= Time.deltaTime;

        if (lifeSpan <= 0)
        {
            Destroy(gameObject);
        }
    }
}
