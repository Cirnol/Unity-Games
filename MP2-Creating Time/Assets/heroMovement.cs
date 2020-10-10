using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heroMovement : MonoBehaviour
{
    Rigidbody2D m_Rigidbody;
    public float initialSpeed = 20f; 
    private float setSpeed = 1f;
    private bool mouse;
    Vector3 mousePos;
    private float degrees;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        mouse = true;
        degrees = 45 * Time.deltaTime * setSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (mouse)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                Debug.Log("Control with WASD now");
                mouse = false;
            }

            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            transform.position = mousePos;

        }
        else 
        {
            m_Rigidbody.velocity = transform.up * initialSpeed;

            if (Input.GetKeyDown(KeyCode.M))
            {
                Debug.Log("Control Mode: Mouse");
                mouse = true;
            }

            if (Input.GetKey(KeyCode.W))
            {
                m_Rigidbody.velocity = transform.up * initialSpeed;
            }

            if (Input.GetKey(KeyCode.S))
            {
                m_Rigidbody.velocity = -transform.up * initialSpeed;
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime * setSpeed, Space.World);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(new Vector3(0, 0, -45) * Time.deltaTime * setSpeed, Space.World);
            }
        }

        // Quitting
        if (Input.GetKeyDown(KeyCode.Q))
            Application.Quit();
    }

    // Transform.up code from: https://docs.unity3d.com/ScriptReference/Transform-up.html 
}
