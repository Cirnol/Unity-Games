using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManipulation : MonoBehaviour {

    public GameObject target;

    private Vector3 targetPos;
    private Vector3 selfPos;
    private Vector3 distance;
    private float d;

    private Vector3 previousPos;
    private Vector3 currentPos;

    public enum LookAtCompute {
        QuatLookRotation = 0,
        TransformLookAt = 1
    };

    public Transform LookAtPosition = null;
    //public LineSegment LineOfSight = null;
    public LookAtCompute ComputeMode = LookAtCompute.QuatLookRotation;
    //public bool OrbitHorizontal = true;

    // Use this for initialization
    void Start () {

        transform.up = Vector3.up;
        transform.forward = Vector3.forward;

        Debug.Assert(LookAtPosition != null);
        //Debug.Assert(LineOfSight != null);
        //LineOfSight.SetWidth(0.2f);
        //LineOfSight.SetPoints(transform.localPosition, LookAtPosition.localPosition);
	}
    Vector3 delta = Vector3.zero;
    Vector3 mouseDownPos = Vector3.zero;


	// Update is called once per frame
	void Update () {
        transform.up = Vector3.up;
        transform.forward = Vector3.forward;

        //LineOfSight.SetPoints(transform.localPosition, LookAtPosition.localPosition);

        //targetPos = target.transform.position;
        selfPos = transform.position;
        distance = targetPos - selfPos;
        d = distance.magnitude;

        switch (ComputeMode)
        {
            case LookAtCompute.QuatLookRotation:
                // Viewing vector is from transform.localPosition to the lookat position
                Vector3 V = LookAtPosition.localPosition - transform.localPosition;
                Vector3 W = Vector3.Cross(-V, transform.up);
                Vector3 U = Vector3.Cross(W, -V);
                transform.localRotation = Quaternion.LookRotation(V, U);
                break;

            case LookAtCompute.TransformLookAt:
                break;
        }

        if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
        {
            // Zooming
            if (Input.GetAxis("Mouse ScrollWheel") < 0 && d < 75) // Zoom out
            {
                ProcesssZoom(1);
            }
            if (Input.GetAxis("Mouse ScrollWheel") > 0 && d > 5) // Zoom in
            {
                ProcesssZoom(-1);
            }

            // Tumbling
            if (Input.GetMouseButtonDown(0))
            {
                mouseDownPos = Input.mousePosition;
                delta = Vector3.zero;
            }
            if (Input.GetMouseButton(0))
            {

                // Obtain Rotation Z value and convert to 360 degrees
                float result = gameObject.transform.rotation.eulerAngles.x - Mathf.CeilToInt(gameObject.transform.rotation.eulerAngles.x / 360f) * 360f;
                if (result < 0)
                {
                    result += 360f;
                }
                // Obtained from https://answers.unity.com/questions/1427258/get-an-eular-angle-between-0-and-360-after-calcula.html

                if(result > 80 && result < 100)
                {
                    delta.y = -1;
                    //transform.rotation = Quaternion.Euler(80, gameObject.transform.rotation.eulerAngles.y, gameObject.transform.rotation.eulerAngles.z);
                }
                else
                {
                    if (result < 280 && result > 100)
                    {
                        delta.y = 1;
                        transform.rotation = Quaternion.Euler(280, gameObject.transform.rotation.eulerAngles.y, gameObject.transform.rotation.eulerAngles.z);
                    }
                    else
                    {
                        delta = mouseDownPos - Input.mousePosition;
                    }
                }

                mouseDownPos = Input.mousePosition;
                ComputeHorizontalOrbit(delta.x, transform.up);
                ComputeHorizontalOrbit(delta.y, transform.right);


                //Add these two lines
                float z = transform.eulerAngles.z;
                transform.Rotate(0, 0, -z);
            }

            //// Panning
            //if (Input.GetMouseButtonDown(1))
            //{
            //    mouseDownPos = Input.mousePosition;
            //    delta = Vector3.zero;
            //}
            //if (Input.GetMouseButton(1))
            //{
            //    delta = mouseDownPos - Input.mousePosition;
            //    Vector3 move = new Vector3(delta.x, delta.y, delta.z);
            //    //Debug.Log(delta);
            //    //target.transform.Translate(delta);
            //    target.transform.localPosition = move;
            //    Debug.Log("TargetPos:" + target.transform.position);
                
            //    //transform.localPosition = move;
            //    mouseDownPos = Input.mousePosition;


            //}
        }
    }

    public void ProcesssZoom(int delta)
    {
        Vector3 v = LookAtPosition.localPosition - transform.localPosition;
        float dist = v.magnitude;
        dist += delta;
        transform.localPosition = LookAtPosition.localPosition - dist * v.normalized;
    }

    const float RotateDelta = 10f / 60;  // about 10-degress per second
    void ComputeHorizontalOrbit(float Direction, Vector3 AxisRot)
    {
        // orbit with respect to the transform.right axis

        // 1. Rotation of the viewing direction by right axis
        Quaternion q = Quaternion.AngleAxis(Direction * RotateDelta, AxisRot);

        // 2. we need to rotate the camera position
        Matrix4x4 r = Matrix4x4.TRS(Vector3.zero, q, Vector3.one);
        Matrix4x4 invP = Matrix4x4.TRS(-LookAtPosition.localPosition, Quaternion.identity, Vector3.one);
        r = invP.inverse * r * invP;
        Vector3 newCameraPos = r.MultiplyPoint(transform.localPosition);
        transform.localPosition = newCameraPos;

        // This replaces built-in look function
        Vector3 V = LookAtPosition.localPosition - transform.localPosition;
        Vector3 W = Vector3.Cross(-V, Vector3.up);
        Vector3 U = Vector3.Cross(W, -V);

        //transform.localRotation = Quaternion.LookRotation(V, U); // This gets replaced by the next 3 lines
        transform.localRotation = Quaternion.FromToRotation(Vector3.up, U);
        Quaternion alignU = Quaternion.FromToRotation(transform.forward, V);
        transform.localRotation = alignU * transform.localRotation;

        if (Mathf.Abs(Vector3.Dot(newCameraPos.normalized, Vector3.up)) > 0.7071f) // this is about 45-degrees
        {
            Direction *= -1f;
        }
    }
}
