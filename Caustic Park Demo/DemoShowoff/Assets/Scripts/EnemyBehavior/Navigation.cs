using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AIPath))]
[RequireComponent(typeof(AIDestinationSetter))]
public class Navigation : MonoBehaviour
{
    public WaypointSystem waypoints;
    public float TimeBeforeStale = 3.0f;
    [HideInInspector] public AIPath path;
    [HideInInspector] public AIDestinationSetter setter;
    [HideInInspector] public Transform currentWaypoint;
    [HideInInspector] public int waypointIndex;

    private Vector3 lastPosition;
    private float staleTimer;

    private void Awake()
    {
        path = GetComponent<AIPath>();
        setter = GetComponent<AIDestinationSetter>();
        staleTimer = TimeBeforeStale;
    }

    private void Start()
    {
        if(waypoints != null)
        {
            waypointIndex = 0;
            currentWaypoint = waypoints.waypoints[0];
            if (currentWaypoint != null)
                setter.target = currentWaypoint;
        }
    }

    private void Update()
    {
        setStale();
        
    }

    public void Stop()
    {
        setter.target = null;
        path.enabled = false;
    }

    public void Resume()
    {
        path.enabled = true;
        if(currentWaypoint == null)
        {
            currentWaypoint = waypoints.waypoints[waypointIndex];
        }
        setter.target = currentWaypoint;
    }

    public void NextWaypoint()
    {
        setter.target = null;
        currentWaypoint = waypoints.waypoints[waypointIndex];
        setter.target = currentWaypoint;
    }

    public void Chase(Transform target)
    {
        path.enabled = true;
        setter.target = target;
    }

    public void SetTarget(Vector3 location)
    {
        path.enabled = true;
        path.destination = location;
    }

    public bool ReachedTarget()
    {
        bool targetReached = path.reachedDestination;
        return targetReached;
    }

    public bool StalePath()
    {
        bool pathStale = (staleTimer <= 0);
        return pathStale;
    }

    private void setStale()
    {
        if((lastPosition - transform.position).magnitude < .001f)
        {
            if(staleTimer > 0)
            {
                staleTimer -= Time.deltaTime;
            }
        }
        else
        {
            staleTimer = TimeBeforeStale;
        }
        lastPosition = transform.position;
    }
}
