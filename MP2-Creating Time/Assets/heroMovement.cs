using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heroMovement : MonoBehaviour
{
    public static bool mouseCheck;
    Vector3 mousePos;

    Rigidbody2D m_Rigidbody;
    private float speed;
    private float initialSpeed;
    
    private float rotateSpeed;
    private Quaternion initialRotation;

    // Start is called before the first frame update
    void Start()
    {
        mouseCheck = true;

        m_Rigidbody = GetComponent<Rigidbody2D>();
        initialSpeed = 20f;
        
        rotateSpeed = 1f;
        initialRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseCheck)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                Debug.Log("Control with WASD now");
                mouseCheck = false;
                m_Rigidbody.velocity = transform.up * initialSpeed;
                speed = initialSpeed;
                Debug.Log("Initial velocity is: " + m_Rigidbody.velocity);
                Debug.Log("Initial speed is: " + speed);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime * rotateSpeed, Space.World);
                m_Rigidbody.velocity = transform.up * speed;
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(new Vector3(0, 0, -45) * Time.deltaTime * rotateSpeed, Space.World);
                m_Rigidbody.velocity = transform.up * speed;
            }

            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            transform.position = mousePos;
        }
        else 
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                Debug.Log("Control Mode: Mouse");
                mouseCheck = true;
                transform.rotation = initialRotation;
            }

            if (Input.GetKey(KeyCode.W))
            {
                speed += Time.deltaTime * initialSpeed;
                m_Rigidbody.velocity = transform.up * speed;
                Debug.Log("Current velocity is: " + m_Rigidbody.velocity);
                Debug.Log("Current speed is: " + speed);
            }

            if (Input.GetKey(KeyCode.S))
            {
                speed -= Time.deltaTime * initialSpeed;
                m_Rigidbody.velocity = transform.up * speed;
                Debug.Log("Current velocity is: " + m_Rigidbody.velocity);
                Debug.Log("Current speed is: " + speed);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime * rotateSpeed, Space.World);
                m_Rigidbody.velocity = transform.up * speed;
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(new Vector3(0, 0, -45) * Time.deltaTime * rotateSpeed, Space.World);
                m_Rigidbody.velocity = transform.up * speed;
            }
        }

        // Quitting
        if (Input.GetKeyDown(KeyCode.Q))
            Application.Quit();
    }

    // Transform.up code from: https://docs.unity3d.com/ScriptReference/Transform-up.html 
}
