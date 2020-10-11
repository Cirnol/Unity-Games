using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldBoundary : MonoBehaviour
{
    private float northLimit;
    private float southLimit;
    private float westLimit;
    private float eastLimit;

    public GameObject _egg;

    // Start is called before the first frame update
    void Start()
    {
        northLimit = 100;
        southLimit = -100;
        westLimit = -264;
        eastLimit = 264;
    }

    // Update is called once per frame
    void Update()
    {
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
