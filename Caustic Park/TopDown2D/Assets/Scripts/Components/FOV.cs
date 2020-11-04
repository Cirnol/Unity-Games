using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using UnityEditor;
using UnityEngine;

public class FOV : MonoBehaviour
{
    //For FOV
    public float ViewRadius = 5;
    public float ViewAngle = 135;
    Collider2D[] playerInRadius;
    public LayerMask ObstacleMask, PlayerMask;
    public List<Transform> VisibleObstacles = new List<Transform>();
    public List<Transform> VisiblePlayers = new List<Transform>();

    //For FOV Mesh
    [SerializeField] bool showMesh = true;
    Mesh mesh;
    MeshRenderer render;
    RaycastHit2D hit;
    [SerializeField] float meshRes = 2;
    [HideInInspector] public Vector3[] vertices;
    [HideInInspector] public int[] trianges;
    [HideInInspector] public int stepCount;
    private List<Vector3> viewVertex;

    private void Start()
    {
        render = GetComponent<MeshRenderer>();
        mesh = GetComponent<MeshFilter>().mesh;

        if (mesh == null)
        {
            mesh = new Mesh();
            GetComponent<MeshFilter>().mesh = mesh;
        }
    }

    private void FixedUpdate()
    {
        FindVisiblePlayer();
    }

    private void LateUpdate()
    {
        if (showMesh)
        {
            if(!render.enabled)
            {
                render.enabled = true;
            }
            MakeMesh();
        }
        else if(render.enabled)
        {
            render.enabled = false;
        }
    }

    private void FindVisiblePlayer()
    {
        VisiblePlayers.Clear();
        VisibleObstacles.Clear();

        stepCount = Mathf.RoundToInt(ViewAngle * meshRes);
        float stepAngle = ViewAngle / stepCount;

        viewVertex = new List<Vector3>();

        hit = new RaycastHit2D();

        for (int i = 0; i < stepCount; i++)
        {
            float angle = transform.eulerAngles.z - ViewAngle / 2 + stepAngle * i + 90;
            Vector3 dir = Utils.GetVectorFromAngle(angle);
            hit = Physics2D.Raycast(transform.position, dir, ViewRadius, ObstacleMask + PlayerMask);

            if(hit.collider == null)
            {
                viewVertex.Add(transform.position + dir.normalized * ViewRadius);
            }
            else
            {
                if (ObstacleMask == (ObstacleMask | (1 << hit.collider.gameObject.layer)))
                {
                    if (!VisibleObstacles.Contains(hit.transform))
                    {
                        VisibleObstacles.Add(hit.transform);
                    }
                }
                else if (PlayerMask == (PlayerMask | (1 << hit.collider.gameObject.layer)))
                {
                    if (!VisiblePlayers.Contains(hit.transform))
                    {
                        VisiblePlayers.Add(hit.transform);
                    }
                }
                viewVertex.Add(transform.position + dir.normalized * hit.distance);
            }
        }
    }

    private void MakeMesh()
    {

        int vertexCount = viewVertex.Count + 1;

        vertices = new Vector3[vertexCount];
        trianges = new int[(vertexCount - 2) * 3];

        vertices[0] = Vector3.zero;
        for (int i = 0; i < vertexCount - 1; i++)
        {
            vertices[i + 1] = transform.InverseTransformPoint(viewVertex[i]);

            if (i < vertexCount - 2)
            {
                trianges[i * 3 + 2] = 0;
                trianges[i * 3 + 1] = i + 1;
                trianges[i * 3] = i + 2;
            }
        }

        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = trianges;
        mesh.RecalculateNormals();
    }

    public void SetFoV(float fov)
    {
        ViewAngle = fov;
    }

    public void SetViewDistance(float dist)
    {
        ViewRadius = dist;
    }
}
