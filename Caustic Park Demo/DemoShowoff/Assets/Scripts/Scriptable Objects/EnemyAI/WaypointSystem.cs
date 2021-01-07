using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Waypoints")]
public class WaypointSystem : ScriptableObject
{
    public List<Transform> waypoints;

    public int NextWaypoint(int currentWaypoint)
    {
        return (currentWaypoint + 1) % waypoints.Count;
    }
}
