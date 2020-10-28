using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimLineMath : MonoBehaviour
{
    public GameObject epA;
    public GameObject epB;
    public GameObject line;

    private Vector3 startLine;
    private Vector3 endLine;
    private float width;

    public static Vector3 offset;

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

        offset = endLine - startLine;
        Vector3 scale = new Vector3(width, offset.magnitude / 2.0f, width);
        var position = startLine + (offset / 2.0f);

        line.transform.up = offset;
        line.transform.localScale = scale;
        line.transform.position = position;
    }

    // Cylinder code from: https://answers.unity.com/questions/21174/create-cylinder-primitive-between-2-endpoints.html
}
