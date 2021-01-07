using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSetter : MonoBehaviour
{
    public WaypointSystem system;
    public List<Transform> waypoints;
    
    void Awake()
    {
        system.waypoints = waypoints;
    }
}
