﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class childMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5;
    private Vector3 mousePosition;
    private Vector3 aimDir;
    private Vector3 exit;

    public Animator animator;
    public Rigidbody2D rgbd;

    private Vector2 movement = Vector3.zero;
    // Update is called once per frame
    void Update()
    {

        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);

        

        //Vector3 vertical = new Vector3(0f, Input.GetAxis("Vertical"), 0f);
        //transform.position = transform.position + vertical * Time.deltaTime * moveSpeed;









    ////transform.LookAt(new Vector3(mousePosition.x, mousePosition.y, transform.position.x));
    //Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
    //transform.rotation = rot;
    //transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

    }

    private void FixedUpdate()
    {
        rgbd.MovePosition(rgbd.position + movement * Time.deltaTime * moveSpeed);

        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        aimDir = mousePosition - gameObject.transform.position;
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        angle = (angle + 360) % 360;  // +360 for implementations where mod returns negative numbers


        if (angle >= 46 && angle <= 135)
        {
            gameObject.GetComponent<Animator>().Play("Child_Look_Up");
        }

        if (angle >= 316 || angle <= 45)
        {
            gameObject.GetComponent<Animator>().Play("Child_Look_Right");
        }

        if (angle >= 226 && angle <= 315)
        {
            gameObject.GetComponent<Animator>().Play("Child_Look_Down");
        }

        if (angle >= 136 && angle <= 225)
        {
            gameObject.GetComponent<Animator>().Play("Child_Look_Left");
        }
    }
}
