using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeMinion : MonoBehaviour
{
    public float setSpeed = 1f;
    public float degrees;
    private bool positive = true;
    private Vector3 move;


    // Start is called before the first frame update
    void Start()
    {
        move = new Vector3(0, 1, 0) * Time.deltaTime * setSpeed;
        degrees = 90 * Time.deltaTime * setSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, degrees, 0);

        if (positive)
        {
            this.transform.Translate(move);
            gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1);
        }
        else
        {
            this.transform.Translate(-move);
            gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 1);
        }

        if (transform.position.y >= 5)
            positive = false;

        if (transform.position.y <= 0.5)
            positive = true;
    }
}
