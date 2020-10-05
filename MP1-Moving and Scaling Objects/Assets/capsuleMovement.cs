using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capsuleMovement : MonoBehaviour
{
    public float setSpeed = 15f;
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = this.transform.position;
        Debug.Log("Start X =" + startPosition.x);
        Debug.Log("Current X =" + transform.position.x);
        Debug.Log("Start Y =" + startPosition.y);
        Debug.Log("Current Y =" + transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {

        if (Mathf.Abs(transform.position.x) < Mathf.Abs(startPosition.x * 50.0f))
        {
            if (Input.GetKey(KeyCode.UpArrow))
            { 
                transform.Translate(new Vector3(startPosition.x, 0, startPosition.z) * Time.deltaTime * setSpeed);
                Debug.Log("Start X =" + startPosition.x);
                Debug.Log("Current X =" + transform.position.x);
                Debug.Log("Start Z =" + startPosition.z);
                Debug.Log("Current Z =" + transform.position.z);
            }
        }
        else
        {
            transform.position = new Vector3((startPosition.x * 50), 0, (startPosition.z * 50));
        }

        if (Mathf.Abs(transform.position.x) > Mathf.Abs(startPosition.x))
        {
            if (Input.GetKey(KeyCode.DownArrow))
                transform.Translate(new Vector3(-startPosition.x, 0, -startPosition.z) * Time.deltaTime * setSpeed);
        }
        else
        {
            transform.position = new Vector3(startPosition.x, 0, startPosition.z);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Quitting Game");
            Application.Quit();
        }
    }
}
