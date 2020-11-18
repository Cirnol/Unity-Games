using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraBehavior : MonoBehaviour
{
    public Camera cam;

    public Transform target;

    private Vector3 targetPos;
    private Vector3 selfPos;
    private Vector3 distance;
    private float d;

    private Vector3 previousPos;
    private Vector3 currentPos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        targetPos = target.transform.position;
        selfPos = transform.position;
        distance = targetPos - selfPos;
        d = distance.magnitude;

        transform.LookAt(target);

        if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
        {
            MouseWheeling();

            if (Input.GetMouseButtonDown(0))
            {
                previousPos = cam.ScreenToViewportPoint(Input.mousePosition);
                currentPos = selfPos;
            }

            // Ok I need to fix this completely
            if (Input.GetMouseButton(0))
            {
                Vector3 direction = previousPos - cam.ScreenToViewportPoint(Input.mousePosition);

                cam.transform.position = new Vector3();
                cam.transform.Rotate(new Vector3(1, 0, 0), direction.y * 180);
                cam.transform.Rotate(new Vector3(0, 1, 0), -direction.x * 180, Space.World);
                cam.transform.Translate(0, 0, currentPos.z);

                previousPos = cam.ScreenToViewportPoint(Input.mousePosition);
            }
        }
    }


    void MouseWheeling()
    {
        Vector3 pos = transform.position;
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && d < 75)
        {
            pos = pos - transform.forward;
            transform.position = pos;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && d > 2)
        {
            pos = pos + transform.forward;
            transform.position = pos;
        }
    } // Code from: https://www.gamasutra.com/blogs/HectorXiang/20190906/350177/Rotate_zoom_and_move_your_camera_with_your_mouse_in_unity3d.php
}
