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

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        speed = 40f;

        northLimit = 100;
        southLimit = -100;
        westLimit = -264;
        eastLimit = 264;
    }

    // Update is called once per frame
    void Update()
    {
        m_Rigidbody.velocity = transform.up * speed;
        Debug.Log("Egg Created");

        if (transform.position.x < westLimit || transform.position.x > westLimit)
        {
            Destroy(gameObject);
            Debug.Log("Egg Deleted");
        }

        if (transform.position.y < southLimit || transform.position.y > northLimit)
        {
            Destroy(gameObject);
            Debug.Log("Egg Deleted");
        }
    }
}
