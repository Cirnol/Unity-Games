using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class enemyPatrol : MonoBehaviour
{
    Rigidbody2D m_Rigidbody;

    private GameObject wpA;
    private GameObject wpB;
    private GameObject wpC;
    private GameObject wpD;
    private GameObject wpE;
    private GameObject wpF;

    private float speed;
    private float rotateSpeed;

    private Transform target;
    private int nextTarget;
    private int targetWaypoint;

    private bool sequential;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        speed = 20f;
        rotateSpeed = 1.5f;
        
        wpA = GameObject.Find("WPA");
        wpB = GameObject.Find("WPB");
        wpC = GameObject.Find("WPC");
        wpD = GameObject.Find("WPD");
        wpE = GameObject.Find("WPE");
        wpF = GameObject.Find("WPF");

        nextTarget = 0;
        sequential = true;
    }

    // Update is called once per frame
    void Update()
    {
        m_Rigidbody.velocity = transform.up * speed;

        targetWaypoint = nextTarget % 6;

        if(targetWaypoint == 0)
            target = wpA.transform;

        if (targetWaypoint == 1)
            target = wpB.transform;
            
        if (targetWaypoint == 2)
            target = wpC.transform;

        if (targetWaypoint == 3)
            target = wpD.transform;

        if (targetWaypoint == 4)
            target = wpE.transform;

        if (targetWaypoint == 5)
            target = wpF.transform;

        PointAtPosition(target);

        if(Vector3.Distance(gameObject.transform.position, target.position) < 25)
        {
            if (sequential)
                nextTarget++;
            else
                nextTarget = Random.Range(0, 5);
        } 

        if (Input.GetKeyDown(KeyCode.J))
            sequential = !sequential;
    }

    void PointAtPosition(Transform pos)
    {
        Vector3 relativePos = pos.position - transform.position;
        float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg - 90;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, q, rotateSpeed * Time.deltaTime);

        // transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        // relativePos.Normalize();
        // transform.Rotate(relativePos * Time.deltaTime * rotateSpeed, Space.World);
    }
}
