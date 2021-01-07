using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamFOV : MonoBehaviour
{
    public float width;
    public float distance;
    public LayerMask ObstacleMask, CharacterMask, InteractableMask, ReflectMask, xrayProof;
    [HideInInspector] public BeamFOVHandler handler;
    
    private Vector3 left;
    private Vector3 leftEnd;
    private Vector3 rightEnd;
    private Vector3 right;
    private RaycastHit2D leftHit;
    private RaycastHit2D rightHit;
    private Mesh mesh;
    private MeshRenderer render;

    private bool init;

    private Vector3[] vertices;
    private int[] triangles;

    private void Awake()
    {
        init = false;
        render = GetComponent<MeshRenderer>();
        mesh = GetComponent<MeshFilter>().mesh;

        if (mesh == null)
        {
            mesh = new Mesh();
            GetComponent<MeshFilter>().mesh = mesh;
        }

        left = transform.position;
        left -= transform.right * width / 2.0f;
        right = transform.position;
        right += transform.right * width / 2.0f;
    }

    private void Update()
    {
        if(handler.active)
        {
            if (!render.enabled)
            {
                render.enabled = true;
            }
            render.material = handler.BeamMaterial;
            MakeMesh();
        }
        else if (render.enabled)
        {
            render.enabled = false;
        }

    }

    private void LateUpdate()
    {
        DrawMesh();
    }

    private void MakeMesh()
    {

        left = transform.position;
        left -= transform.right * width / 2.0f;
        right = transform.position;
        right += transform.right * width / 2.0f;

        leftHit = new RaycastHit2D();
        rightHit = new RaycastHit2D();

        bool reflectL = false;
        bool reflectR = false;

        ReflectionHandler l = null;
        ReflectionHandler r = null;

        Beam point1 = new Beam();
        Beam point2 = new Beam();
        leftHit = Physics2D.Raycast(left, transform.up, distance, ObstacleMask + CharacterMask + InteractableMask + xrayProof);
        rightHit = Physics2D.Raycast(right, transform.up, distance, ObstacleMask + CharacterMask + InteractableMask + xrayProof);
        if (handler.bulb.power == Bulb.Power.XRAY)
        {
            leftHit = Physics2D.Raycast(left, transform.up, distance, CharacterMask + InteractableMask + xrayProof);
        }
        if (handler.bulb.power == Bulb.Power.XRAY)
        {
            rightHit = Physics2D.Raycast(right, transform.up, distance, CharacterMask + InteractableMask + xrayProof);
        }
        if (leftHit.collider == null)
        {
            leftEnd = left + transform.up * distance;
        }
        else if(InteractableMask == (InteractableMask | (1 << leftHit.collider.gameObject.layer)))
        {
            setLists(leftHit);
            if (handler.bulb.power == Bulb.Power.XRAY)
            {
                leftHit = Physics2D.Raycast(left, transform.up, distance, CharacterMask + xrayProof);
            }
            else
            {
                leftHit = Physics2D.Raycast(left, transform.up, distance, ObstacleMask + CharacterMask + xrayProof);
            }
            if(leftHit.collider == null)
            {
                leftEnd = left + transform.up * distance;
            }
            else if (xrayProof == (xrayProof | (1 << leftHit.collider.gameObject.layer)))
            {
                leftEnd = leftHit.point;
            }
            else
            {
                leftEnd = leftHit.point;

                reflectL = true;
                l = leftHit.collider.GetComponent<ReflectionHandler>();
                float deltaD = distance - (leftEnd - left).magnitude;
                point1 = new Beam(leftEnd, deltaD, Vector3.Reflect(transform.up, leftHit.normal));

            }
        }
        else if (CharacterMask == (CharacterMask | (1 << leftHit.collider.gameObject.layer)))
        {
            setLists(leftHit);
            leftHit = Physics2D.Raycast(left, transform.up, distance, xrayProof);
            
            if (leftHit.collider == null)
            {
                leftEnd = left + transform.up * distance;
            }
            else if (xrayProof == (xrayProof | (1 << leftHit.collider.gameObject.layer)))
            {
                leftEnd = leftHit.point;
            }
            else
            {
                leftEnd = leftHit.point;

                reflectL = true;
                l = leftHit.collider.GetComponent<ReflectionHandler>();
                float deltaD = distance - (leftEnd - left).magnitude;
                point1 = new Beam(leftEnd, deltaD, Vector3.Reflect(transform.up, leftHit.normal));

            }

        }
        else if (xrayProof == (xrayProof| (1 << leftHit.collider.gameObject.layer)))
        {
            leftEnd = leftHit.point;
        }
        else
        {
            leftEnd = leftHit.point;

            reflectL = true;
            l = leftHit.collider.GetComponent<ReflectionHandler>();
            float deltaD = distance - (leftEnd - left).magnitude;
            point1 = new Beam(leftEnd, deltaD, Vector3.Reflect(transform.up, leftHit.normal));

        }
        if (rightHit.collider == null)
        {
            rightEnd = right + transform.up * distance;
        }
        else if (InteractableMask == (InteractableMask | (1 << rightHit.collider.gameObject.layer)))
        {
            setLists(rightHit);
            if (handler.bulb.power == Bulb.Power.XRAY)
            {
                rightHit = Physics2D.Raycast(right, transform.up, distance, CharacterMask + xrayProof);
            }
            else
            {
                rightHit = Physics2D.Raycast(right, transform.up, distance, ObstacleMask + CharacterMask + xrayProof);
            }
            
            if (rightHit.collider == null)
            {
                rightEnd = right + transform.up * distance;
            }
            else if (xrayProof == (xrayProof | (1 << rightHit.collider.gameObject.layer)))
            {
                rightEnd = rightHit.point;
            }
            else
            {
                rightEnd = rightHit.point;

                reflectR = true;
                r = rightHit.collider.GetComponent<ReflectionHandler>();
                float deltaD = distance - (rightEnd - right).magnitude;
                point2 = new Beam(rightEnd, deltaD, Vector3.Reflect(transform.up, rightHit.normal));

            }
        }
        else if (CharacterMask == (CharacterMask | (1 << rightHit.collider.gameObject.layer)))
        {
            setLists(rightHit);
            rightHit = Physics2D.Raycast(right, transform.up, distance, xrayProof);

            if (rightHit.collider == null)
            {
                rightEnd = right + transform.up * distance;
            }
            else if (xrayProof == (xrayProof | (1 << rightHit.collider.gameObject.layer)))
            {
                rightEnd = rightHit.point;
            }
            else
            {
                rightEnd = rightHit.point;

                reflectR = true;
                r = rightHit.collider.GetComponent<ReflectionHandler>();
                float deltaD = distance - (rightEnd - right).magnitude;
                point2 = new Beam(rightEnd, deltaD, Vector3.Reflect(transform.up, rightHit.normal));

            }

        }
        else if (xrayProof == (xrayProof | (1 << rightHit.collider.gameObject.layer)))
        {
            rightEnd = rightHit.point;
        }
        else
        {
            rightEnd = rightHit.point;

            reflectR = true;
            r = rightHit.collider.GetComponent<ReflectionHandler>();
            float deltaD = distance - (rightEnd - right).magnitude;
            point2 = new Beam(rightEnd, deltaD, Vector3.Reflect(transform.up, rightHit.normal));
        }
        if (!init)
            init = true;

        if(reflectL && reflectR && l != null)
        {
            if(l == r)
            {
                l.AddBeam(point1, point2);
            }
        }

        setLists(leftHit);
        setLists(rightHit);
    }

    private void DrawMesh()
    {
        if (mesh == null || !init)
            return;
        vertices = new Vector3[4];

        vertices[0] = transform.InverseTransformPoint(leftEnd);
        vertices[1] = transform.InverseTransformPoint(rightEnd); ;
        vertices[2] = transform.InverseTransformPoint(left); ;
        vertices[3] = transform.InverseTransformPoint(right); ;

        triangles = new int[6];

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;
        triangles[3] = 2;
        triangles[4] = 1;
        triangles[5] = 3;

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }

    private void setLists(RaycastHit2D hit)
    {
        if(hit.collider != null)
        {
            if (ObstacleMask == (ObstacleMask | (1 << hit.collider.gameObject.layer)))
            {
                handler.AddObstacle(hit.collider.transform);
            }

            else if (CharacterMask == (CharacterMask | (1 << hit.collider.gameObject.layer)))
            {
                handler.AddCharacter(hit.collider.transform);
            }

            else if (InteractableMask == (InteractableMask | (1 << hit.collider.gameObject.layer)))
            {
                handler.AddInteractable(hit.collider.transform);
            }
        }
    }

    public struct Beam
    {
        public Vector3 Point;
        public float Distance;
        public Vector3 Dir;

        public Beam(Vector3 p, float dist, Vector3 dir)
        {
            Point = p;
            Distance = dist;
            Dir = dir;
        }
    }
}
