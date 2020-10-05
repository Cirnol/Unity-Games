using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capsuleMovement : MonoBehaviour
{
    public float setSpeed = 20f;
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Translation
        if (Mathf.Abs(transform.position.x) < Mathf.Abs(startPosition.x * 50.0f))
        {
            if (Input.GetKey(KeyCode.UpArrow))
                transform.Translate(new Vector3(startPosition.x, 0, startPosition.z) * Time.deltaTime * setSpeed);
        }
        else
            transform.position = new Vector3((startPosition.x * 50), 0, (startPosition.z * 50));

        if (Mathf.Abs(transform.position.x) > Mathf.Abs(startPosition.x))
        {
            if (Input.GetKey(KeyCode.DownArrow))
                transform.Translate(new Vector3(-startPosition.x, 0, -startPosition.z) * Time.deltaTime * setSpeed);
        }
        else
            transform.position = new Vector3(startPosition.x, 0, startPosition.z);

        // Scaling
        float s = Input.GetAxis("Vertical") * 0.1f;
        Vector3 size = new Vector3(s, s, s);
        this.transform.localScale += size;

        if (transform.localScale.x > 5.9f)
            transform.localScale = new Vector3(5.9f, 5.9f, 5.9f);
        else if (transform.localScale.x < 1.0f)
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        // Quitting
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Quitting Game");
            Application.Quit();
        }
    }
}
