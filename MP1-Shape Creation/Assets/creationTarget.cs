using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class creationTarget : MonoBehaviour
{
    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
        Debug.Log("X = " + target.x);
        Debug.Log("Z = " + target.z);
        Debug.Log("Sphere X = " + transform.position.x);
        Debug.Log("Sphere Z = " + transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                target = hit.point;
                target.y = transform.position.y;
                transform.position = target;
                Debug.Log("X = " + target.x);
                Debug.Log("Z = " + target.z);
                Debug.Log("Sphere X = " + transform.position.x);
                Debug.Log("Sphere Z = " + transform.position.z);
            }
        }

        //Raycast code obtained from: https://answers.unity.com/questions/773911/move-object-to-mouse-click-position.html 
    }
}
