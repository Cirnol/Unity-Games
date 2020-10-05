using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capsuleMovement : MonoBehaviour
{
    public float setSpeed = 60f;
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
        float m = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(m * startPosition.x, m * startPosition.y, m * startPosition.z) * Time.deltaTime * setSpeed;
        this.transform.Translate(move);

        if (Mathf.Abs(transform.position.x) > Mathf.Abs(startPosition.x * 50.0f))
            transform.position = new Vector3((startPosition.x * 50), (startPosition.y * 50), (startPosition.z * 50));
        else if (Mathf.Abs(transform.position.x) < Mathf.Abs(startPosition.x))
            transform.position = new Vector3(startPosition.x, startPosition.y, startPosition.z);

        // Scaling
        float s = Input.GetAxis("Vertical") * 0.1f;
        Vector3 size = new Vector3(s, s, s) * Time.deltaTime * setSpeed;
        this.transform.localScale += size;

        if (transform.localScale.x > 5.9f)
            transform.localScale = new Vector3(5.9f, 5.9f, 5.9f);
        else if (transform.localScale.x < 1.0f)
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        // Quitting
        if (Input.GetKeyDown(KeyCode.Q))
            Application.Quit();
    }
}
