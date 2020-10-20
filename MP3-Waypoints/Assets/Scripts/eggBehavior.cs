using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eggBehavior : MonoBehaviour
{
    Rigidbody2D m_Rigidbody;
    private float speed;

    private float northLimit;
    private float southLimit;
    private float westLimit;
    private float eastLimit;

    public static int eggsVisible;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        speed = 40f;

        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));
        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        northLimit = topCorner.y;
        southLimit = bottomCorner.y;
        westLimit = bottomCorner.x;
        eastLimit = topCorner.x;

        eggsVisible += 1;
    }

    // Update is called once per frame
    void Update()
    {
        m_Rigidbody.velocity = transform.up * speed;

        if ( transform.position.x < westLimit || transform.position.x > eastLimit ||
            transform.position.y < southLimit || transform.position.y > northLimit )
        {
            Destroy(gameObject);
            eggsVisible -= 1;
        }
    }

    void OnCollisionEnter2D(Collision2D otherThing)
    {
        if (otherThing.gameObject.tag == "Enemy" || otherThing.gameObject.tag == "Waypoint")
        {
            Destroy(gameObject);
            eggsVisible -= 1;
        }
    }
}
