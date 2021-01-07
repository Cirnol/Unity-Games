using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamFOVHandler : MonoBehaviour
{
    public int BeamCount;
    public float BeamWidth;
    public float Distance;
    public Bulb bulb;
    public LayerMask ObstacleMask, CharacterMask, InteractableMask, ReflectMask, xrayProof;
    public List<BeamFOV> Segments = new List<BeamFOV>();
    public Material BeamMaterial;
    public bool active = false;

    public List<Transform> VisibleObstacles = new List<Transform>();
    public List<Transform> VisibleCharacters = new List<Transform>();
    public List<Transform> VisibleInteractables = new List<Transform>();

    private TheWorld[] allWorlds;

    private int worldCompleteCount = 0;

    public bool goodToGo = false;



    void Start()
    {
        allWorlds = FindObjectsOfType<TheWorld>();

        float beamWidth = BeamWidth / BeamCount;
        Vector3 startPosition = transform.position - transform.right * BeamWidth / 2;
        Vector3 nextPosition = startPosition;

        for (int i = 0; i < BeamCount; i++)
        {
            nextPosition = startPosition + ((beamWidth) * transform.right * (i + 1));
            nextPosition -= transform.right * beamWidth / 2.0f;

            GameObject beam = new GameObject("BeamSegment");

            beam.transform.parent = transform;
            beam.transform.position = nextPosition;
            beam.AddComponent<MeshFilter>();
            beam.AddComponent<MeshRenderer>().material = BeamMaterial;
            beam.transform.up = transform.up;
            beam.layer = gameObject.layer;

            BeamFOV fov = beam.AddComponent<BeamFOV>();

            fov.width = beamWidth;
            fov.distance = Distance;
            fov.ObstacleMask = ObstacleMask;
            fov.CharacterMask = CharacterMask;
            fov.InteractableMask = InteractableMask;
            fov.ReflectMask = ReflectMask;
            fov.xrayProof = xrayProof;
            fov.handler = this;

            Segments.Add(fov);
        }
    }

    public void Update()
    {
        BeamMaterial = bulb.material;
    }

    public void Clear()
    {
        VisibleObstacles.Clear();
        VisibleCharacters.Clear();
        VisibleInteractables.Clear();
        
    }

    public void AddObstacle(Transform obs)
    {
        if(!VisibleObstacles.Contains(obs))
        {
            VisibleObstacles.Add(obs);
        }
    }

    public void AddCharacter(Transform charact)
    {
        if (!VisibleCharacters.Contains(charact))
        {
            VisibleCharacters.Add(charact);
        }
    }

    public void AddInteractable(Transform inter)
    {
        Debug.Log(inter.name);
        if (!VisibleInteractables.Contains(inter))
        {
            VisibleInteractables.Add(inter);
        }
    }

    public void AddHit(RaycastHit2D hit)
    {
        if (hit.collider != null)
        {
            if (ObstacleMask == (ObstacleMask | (1 << hit.collider.gameObject.layer)) && bulb.power != Bulb.Power.XRAY)
            {
                AddObstacle(hit.collider.transform);
            }

            else if (xrayProof == (xrayProof| (1 << hit.collider.gameObject.layer)))
            {
                AddObstacle(hit.collider.transform);
            }

            else if (CharacterMask == (CharacterMask | (1 << hit.collider.gameObject.layer)))
            {
                AddCharacter(hit.collider.transform);
            }

            else if (InteractableMask == (InteractableMask | (1 << hit.collider.gameObject.layer)))
            {
                AddInteractable(hit.collider.transform);
            }
        }
    }

    public bool IsInteractableSeen(Transform obj)
    {
        return VisibleInteractables.Contains(obj);
    }

    public bool IsPlayerSeen(Transform obj)
    {
        return VisibleCharacters.Contains(obj);
    }
}
