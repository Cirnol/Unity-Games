using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armMovement : MonoBehaviour
{
    private Vector3 mousePosition;
    private Vector3 aimDir;

    public GameObject arm;
    private SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void armUpdate()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        aimDir = mousePosition - gameObject.transform.position;
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg - 90;
        transform.eulerAngles = new Vector3(0, 0, angle);
        angle = (angle + 90 + 360) % 360;

        rend = arm.GetComponent<SpriteRenderer>();

        if (angle >= 46 && angle <= 135) // Up
        {
            rend.sortingOrder = 1;
        }

        if (angle >= 316 || angle <= 45) // Right
        {
            rend.sortingOrder = 1;
        }

        if (angle >= 226 && angle <= 315) // Down
        {
            rend.sortingOrder = 4;
        }

        if (angle >= 136 && angle <= 225) // Left
        {
            
            rend.sortingOrder = 4;
        }

        
        //transform.LookAt(new Vector3(mousePosition.x, mousePosition.y, transform.position.x));
        //Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
        //transform.rotation = rot;
        //transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

    }
}
