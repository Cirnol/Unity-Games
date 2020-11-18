using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManipulation : MonoBehaviour {

    //public Transform target;

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
        Debug.Assert(LookAtPosition != null);
        //Debug.Assert(LineOfSight != null);
        //LineOfSight.SetWidth(0.2f);
        //LineOfSight.SetPoints(transform.localPosition, LookAtPosition.localPosition);
	}
    Vector3 delta = Vector3.zero;
    Vector3 mouseDownPos = Vector3.zero;


	// Update is called once per frame
	void Update () {
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
                delta = mouseDownPos - Input.mousePosition;
                mouseDownPos = Input.mousePosition;
                ComputeHorizontalOrbit(delta.x, transform.up);
                ComputeHorizontalOrbit(delta.y, transform.right);

                //if (transform.localRotation.y != 0)
                //{
                //    transform.localRotation = Quaternion.Euler(transform.localRotation.x, 0, transform.localRotation.z);
                //}

                //if (transform.localRotation.x > 0.7071f)
                //{
                //    return;
                //}

                //if (transform.localRotation.x < -0.7071f)
                //{
                //    return;
                //}
            }
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

        // Replaces built-in LookAt function
        Vector3 V = LookAtPosition.localPosition - transform.localPosition;
        Vector3 W = Vector3.Cross(-V, transform.up);
        Vector3 U = Vector3.Cross(W, -V);
        transform.localRotation = Quaternion.LookRotation(V, U);
        //

        if (Mathf.Abs(Vector3.Dot(newCameraPos.normalized, Vector3.up)) > 0.7071f) // this is about 45-degrees
        {
            Direction *= -1f;
        }
    }
}
