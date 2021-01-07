using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent (typeof(MeshFilter))]
[RequireComponent (typeof(MeshRenderer))]
public class FOV : MonoBehaviour
{
    //For FOV
    public Lens lens;
    public Bulb bulb;
    public LayerMask ObstacleMask, CharacterMask, InteractableMask, ReflectMask, EnemyBlockerMask, xrayProof;
    public float radiusFactor = 1.0f;
    [HideInInspector] public List<Transform> VisibleObstacles = new List<Transform>();
    [HideInInspector] public List<Transform> VisibleCharacters = new List<Transform>();
    [HideInInspector] public List<Transform> VisibleInteractables = new List<Transform>();


    //For FOV Mesh
    [SerializeField] public bool showMesh = true;
    Mesh mesh;
    MeshRenderer render;
    [SerializeField]
    MeshRenderer radiusRenderer;
    RaycastHit2D hit;
    [SerializeField] float meshRes = 2;
    [HideInInspector] public Vector3[] vertices;
    [HideInInspector] public int[] trianges;
    [HideInInspector] public int stepCount;
    private List<Vector3> viewVertex;

    [SerializeField] bool isEnemy;

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

    private void Update()
    {
        FindFOVDef();
        render.material = bulb.material;
        if(radiusRenderer != null)
            radiusRenderer.material = bulb.material;
    }

    private void LateUpdate()
    {
        if (showMesh)
        {
            if (!render.enabled)
            {
                render.enabled = true;
            }
            MakeMesh();
        }
        else if (render.enabled)
        {
            render.enabled = false;
        }
    }

    private void FindFOVDef()
    {

        VisibleCharacters.Clear();
        VisibleObstacles.Clear();
        VisibleInteractables.Clear();

        if (!showMesh)
        {
            return;
        }

        stepCount = Mathf.RoundToInt(lens.fov * meshRes);
        float stepAngle = lens.fov / stepCount;

        viewVertex = new List<Vector3>();

        hit = new RaycastHit2D();
        for (int i = 0; i < stepCount; i++)
        {
            float angle = transform.eulerAngles.z - lens.fov / 2 + stepAngle * i + 90;
            Vector3 dir = Utils.GetVectorFromAngle(angle);
            if (isEnemy)
            {
                hit = Physics2D.Raycast(transform.position, dir, lens.radius * radiusFactor, ObstacleMask + CharacterMask + InteractableMask + EnemyBlockerMask + xrayProof);
            }
            else if (bulb.power == Bulb.Power.XRAY)
            {
                hit = Physics2D.Raycast(transform.position, dir, lens.radius * radiusFactor, CharacterMask + InteractableMask + xrayProof);
            }
            else 
            {  
                hit = Physics2D.Raycast(transform.position, dir, lens.radius * radiusFactor, ObstacleMask + CharacterMask + InteractableMask + xrayProof);
            }

            if (hit.collider == null)
            {
                viewVertex.Add(transform.position + dir.normalized * lens.radius * radiusFactor);
            }
            else if (InteractableMask == (InteractableMask | (1 << hit.collider.gameObject.layer)))
            {
                if (!VisibleInteractables.Contains(hit.transform))
                {
                    VisibleInteractables.Add(hit.transform);
                }
                if (bulb.power == Bulb.Power.XRAY)
                {
                    hit = Physics2D.Raycast(transform.position, dir, lens.radius * radiusFactor, CharacterMask + xrayProof);
                }
                else
                {
                    hit = Physics2D.Raycast(transform.position, dir, lens.radius * radiusFactor, ObstacleMask + CharacterMask + xrayProof);
                }
            }

            if (hit.collider == null)
            {
                viewVertex.Add(transform.position + dir.normalized * lens.radius * radiusFactor);
            }
            else if (CharacterMask == (CharacterMask | (1 << hit.collider.gameObject.layer)))
            {
                if (!VisibleCharacters.Contains(hit.transform))
                {
                    VisibleCharacters.Add(hit.transform);
                }
                if (bulb.power == Bulb.Power.XRAY)
                {
                    hit = Physics2D.Raycast(transform.position, dir, lens.radius * radiusFactor, xrayProof);
                } else
                {
                    hit = Physics2D.Raycast(transform.position, dir, lens.radius * radiusFactor, ObstacleMask + xrayProof);
                }
            }


            if (hit.collider != null && xrayProof == (xrayProof | (1 << hit.collider.gameObject.layer)))
            {
                if (!VisibleObstacles.Contains(hit.transform))
                {
                    VisibleObstacles.Add(hit.transform);
                }
                viewVertex.Add(hit.point);
            }
            else if (hit.collider == null || bulb.power == Bulb.Power.XRAY)
            {
                viewVertex.Add(transform.position + dir.normalized * lens.radius * radiusFactor);
            }
            else
            {
                //Debug.Log("hitting a behindmask");
                if (ObstacleMask == (ObstacleMask | (1 << hit.collider.gameObject.layer)) || (isEnemy && EnemyBlockerMask == (EnemyBlockerMask | (1 << hit.collider.gameObject.layer))))
                {
                    if (!VisibleObstacles.Contains(hit.transform))
                    {
                        VisibleObstacles.Add(hit.transform);
                    }
                }
                viewVertex.Add(hit.point);
            }


        }

        foreach(Transform t in VisibleCharacters)
        {
            LightUp l = t.gameObject.GetComponent<LightUp>();
            if(l != null)
            {
                l.Light();
            }
        }
        foreach (Transform t in VisibleInteractables)
        {
            LightUp l = t.gameObject.GetComponent<LightUp>();
            if (l != null)
            {
                l.Light();
            }
        }
        foreach (Transform t in VisibleObstacles)
        {
            LightUp l = t.gameObject.GetComponent<LightUp>();
            if (l != null)
            {
                l.Light();
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

    public void SetLens(Lens fov)
    {
        this.lens = fov;
    }

    public bool IsPlayerSeen(Transform obj)
    {
        return VisibleCharacters.Contains(obj);
    }

    public bool IsInteractableSeen(Transform obj)
    {
        return VisibleInteractables.Contains(obj);
    }

    public bool IsEnemySeen(Transform obj)
    {
        return VisibleCharacters.Contains(obj);
    }

    public bool EnemyVisible()
    {
        return VisibleCharacters.Count > 0;
    }

    public void toggleMesh()
    {
        showMesh = !showMesh;
    }

    public void toggleMesh(bool toggle)
    {
        showMesh = toggle;
    }
}
