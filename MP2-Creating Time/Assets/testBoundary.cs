using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testBoundary : MonoBehaviour
{
    private float northLimit;
    private float southLimit;
    private float westLimit;
    private float eastLimit;

    // Start is called before the first frame update
    void Start()
    {
        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));
        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        northLimit = topCorner.y;
        southLimit = bottomCorner.y;
        westLimit = bottomCorner.x;
        eastLimit = topCorner.x;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.X))
            transform.position = new Vector3((eastLimit), (northLimit), (0));
    }
}
