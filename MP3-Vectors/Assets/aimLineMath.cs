using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimLineMath : MonoBehaviour
{
    public GameObject epA;
    public GameObject epB;

    private Vector3 startLine;
    private Vector3 endLine;
    private float width;

    // Start is called before the first frame update
    void Start()
    {
        width = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        startLine = epA.transform.position;
        endLine = epB.transform.position;

        Vector3 offset = endLine - startLine;
        Vector3 scale = new Vector3(width, offset.magnitude / 2.0f, width);
        var position = startLine + (offset / 2.0f);

        transform.up = offset;
        transform.localScale = scale;
        transform.position = position;
    }

    // Cylinder code from: https://answers.unity.com/questions/21174/create-cylinder-primitive-between-2-endpoints.html
}
