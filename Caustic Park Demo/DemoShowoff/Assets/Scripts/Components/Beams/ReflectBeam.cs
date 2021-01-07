using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ReflectBeam : MonoBehaviour
{
    public LayerMask ObstacleMask, CharacterMask, InteractableMask, ReflectMask;

    public ReflectionHandler myHandler;

    public LightUp lightup;

    private List<BeamPair> beams = new List<BeamPair>();
    private List<Vector3> verts = new List<Vector3>();
    private List<int> tri = new List<int>();
    private Vector3[] vertices;
    private int[] triangles;
    private float timer = 0.0f;
    private float maxTime = 0.01f;
    public Collider2D col;
    private Mesh mesh;
    private MeshRenderer render;

    private void Awake()
    {
        render = GetComponent<MeshRenderer>();
        mesh = GetComponent<MeshFilter>().mesh;

        if (mesh == null)
        {
            mesh = new Mesh();
            GetComponent<MeshFilter>().mesh = mesh;
        }
    }

    private void Update()
    {
        render.material = myHandler.handler.BeamMaterial;
        if(myHandler.handler.active)
        {
            MakeMesh();
            DrawMesh();
        }
        else
        {
            mesh.Clear();
        }


        tri.Clear();
        verts.Clear();
        beams.Clear();
    }

    public void AddBeam(BeamFOV.Beam ray1, BeamFOV.Beam ray2)
    {
        beams.Add(new BeamPair(ray2, ray1));
    }

    public struct BeamPair
    {
        public BeamFOV.Beam Beam1;
        public BeamFOV.Beam Beam2;

        public BeamPair(BeamFOV.Beam beam1, BeamFOV.Beam beam2)
        {
            Beam1 = beam1;
            Beam2 = beam2;
        }
    }

    private void MakeMesh()
    {
        timer += Time.deltaTime;
        if(timer < maxTime)
        {
            return;
        }
        if (beams.Count <= 0)
            return;

        lightup.Light();
        foreach (BeamPair pair in beams)
        {
            Vector3 left = pair.Beam1.Point;
            Vector3 leftEnd;
            Vector3 right = pair.Beam2.Point;
            Vector3 rightEnd;

            RaycastHit2D leftHit = new RaycastHit2D();
            RaycastHit2D rightHit = new RaycastHit2D();

            bool reflectL = false;
            bool reflectR = false;

            ReflectionHandler l = null;
            ReflectionHandler r = null;

            BeamFOV.Beam point1 = new BeamFOV.Beam();
            BeamFOV.Beam point2 = new BeamFOV.Beam();

            col.enabled = false;

            leftHit = Physics2D.Raycast(left, pair.Beam1.Dir, pair.Beam1.Distance, ObstacleMask + CharacterMask + InteractableMask);
            rightHit = Physics2D.Raycast(right, pair.Beam2.Dir, pair.Beam2.Distance, ObstacleMask + CharacterMask + InteractableMask);
            //myHandler.handler.AddHit(leftHit);
            //myHandler.handler.AddHit(rightHit);
            

            if (myHandler.handler.bulb.power == Bulb.Power.XRAY)
            {
                rightHit = Physics2D.Raycast(right, pair.Beam2.Dir, pair.Beam2.Distance, CharacterMask + InteractableMask);
            }
            if (myHandler.handler.bulb.power == Bulb.Power.XRAY)
            {
                leftHit = Physics2D.Raycast(left, pair.Beam1.Dir, pair.Beam1.Distance, CharacterMask + InteractableMask);
            }
            if (leftHit.collider == null)
            {
                leftEnd = left + pair.Beam1.Dir * pair.Beam1.Distance;
            }
            else if (InteractableMask == (InteractableMask | (1 << leftHit.collider.gameObject.layer)))
            {
                myHandler.handler.AddInteractable(leftHit.collider.gameObject.transform);
                if (myHandler.handler.bulb.power == Bulb.Power.XRAY)
                {
                    leftHit = Physics2D.Raycast(left, pair.Beam1.Dir, pair.Beam1.Distance, CharacterMask);
                }
                else
                {
                    leftHit = Physics2D.Raycast(left, pair.Beam1.Dir, pair.Beam1.Distance, ObstacleMask + CharacterMask);
                }
            } else
            {
                myHandler.handler.AddHit(leftHit);
            }
            if (rightHit.collider == null)
            {
                rightEnd = right + pair.Beam2.Dir * pair.Beam2.Distance;
            }

            else if (InteractableMask == (InteractableMask | (1 << rightHit.collider.gameObject.layer)))
            {
                myHandler.handler.AddInteractable(rightHit.collider.gameObject.transform);
                if (myHandler.handler.bulb.power == Bulb.Power.XRAY)
                {
                    rightHit = Physics2D.Raycast(right, pair.Beam2.Dir, pair.Beam2.Distance, CharacterMask);
                } else
                {
                    rightHit = Physics2D.Raycast(right, pair.Beam2.Dir, pair.Beam2.Distance, ObstacleMask + CharacterMask);
                }
            } else
            {
                myHandler.handler.AddHit(rightHit);
            }
            

            col.enabled = true;


            if (leftHit.collider == null)
            {
                leftEnd = left + pair.Beam1.Dir * pair.Beam1.Distance;
            }
            else
            {
                leftEnd = leftHit.point;

                reflectL = true;
                l = leftHit.collider.GetComponent<ReflectionHandler>();
                float deltaD = pair.Beam1.Distance - (leftEnd - left).magnitude;
                point1 = new BeamFOV.Beam(leftEnd, deltaD, Vector3.Reflect(pair.Beam1.Dir, leftHit.normal));

            }
            if (rightHit.collider == null)
            {
                rightEnd = right + pair.Beam2.Dir * pair.Beam2.Distance;
            }
            else
            {
                rightEnd = rightHit.point;

                reflectR = true;
                r = rightHit.collider.GetComponent<ReflectionHandler>();
                float deltaD = pair.Beam2.Distance - (rightEnd - right).magnitude;
                point2 = new BeamFOV.Beam(rightEnd, deltaD, Vector3.Reflect(pair.Beam2.Dir, rightHit.normal));
            }

            if (reflectL && reflectR && l != null)
            {
                if (l == r)
                {
                    l.AddBeam(point1, point2);
                }
            }

            int topLeft = AddPoint(leftEnd);
            int topRight = AddPoint(rightEnd);
            int botLeft = AddPoint(left);
            int botRight = AddPoint(right);

            AddRect(topLeft, topRight, botLeft, botRight);
        }
    }

    private void DrawMesh()
    {
        vertices = new Vector3[4];
        
        vertices = new Vector3[verts.Count];

        for (int i = 0; i < verts.Count; i++)
        {
            vertices[i] = transform.InverseTransformPoint(verts[i]);
        }

        triangles = new int[tri.Count];

        for(int i = 0; i < tri.Count; i++)
        {
            triangles[i] = tri[i];
        }

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }

    private int AddPoint(Vector3 point)
    {
        if(!verts.Contains(point))
        {
            verts.Add(point);
        }
        return verts.IndexOf(point);
    }

    //0, 1, 2, 3
    private void AddRect(int topLeft, int topRight, int botLeft, int botRight)
    {
        tri.Add(topLeft);
        tri.Add(topRight);
        tri.Add(botLeft);
        tri.Add(botLeft);
        tri.Add(topRight);
        tri.Add(botRight);
    }
}
