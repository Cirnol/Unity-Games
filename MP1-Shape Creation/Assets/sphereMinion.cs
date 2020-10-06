using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereMinion : MonoBehaviour
{
    public float setSpeed = 1f;
    private bool positive = true;
    private Vector3 move;

    // Start is called before the first frame update
    void Start()
    {
        move = new Vector3(1, 0, 0) * Time.deltaTime * setSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (positive)
        {
            this.transform.Translate(move);
            gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1);
        }
        else
        {
            this.transform.Translate(-move);
            gameObject.GetComponent<Renderer>().material.color = new Color(0, 1, 1);
        }
      
        if (transform.position.x >= 5)
            positive = false;

        if (transform.position.x <= 0)
            positive = true;
    }
}
