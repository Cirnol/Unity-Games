using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    public bool randomMovement = false;
    public GameObject currentWaypoint;
    private int index;
    [SerializeField] private WaypointSystem waypoints;
    [SerializeField] private float speed = 20.0f;
    [SerializeField] private float angularSpeed = 120.0f;

    void Start()
    {
        waypoints = FindObjectOfType<WaypointSystem>();
        index = 0;
        GetNextWaypoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (waypoints == null)
            return;
        updateRotation();
        updateLocation();
        if(checkPosition())
        {
            GetNextWaypoint();
        }
    }

    public void ToggleMovement(bool random)
    {
        randomMovement = random;
    }

    private void updateRotation()
    {
        Vector3 v = currentWaypoint.transform.position - transform.position;
        transform.up = Vector3.LerpUnclamped(transform.up, v.normalized, .05f);
    }

    private void updateLocation()
    {
        transform.position += transform.up * 20 * Time.deltaTime;
    }

    private bool checkPosition()
    {
        Vector3 delta = currentWaypoint.transform.position - transform.position;
        if(delta.magnitude < 25)
        {
            return true;
        }
        return false;
    }

    private void GetNextWaypoint()
    {
        if (waypoints == null)
            return;
        if (currentWaypoint == null)
        {
            currentWaypoint = waypoints.waypoints[index];
        }
        else
        {
            if (randomMovement)
            {
                currentWaypoint = waypoints.waypoints[Random.Range(0, waypoints.waypoints.Count)];
                index = (waypoints.waypoints.IndexOf(currentWaypoint) + 1) % waypoints.waypoints.Count;
            }
            else
            {
                currentWaypoint = waypoints.waypoints[index++];
                index = index % waypoints.waypoints.Count;
            }
        }
    }
}
