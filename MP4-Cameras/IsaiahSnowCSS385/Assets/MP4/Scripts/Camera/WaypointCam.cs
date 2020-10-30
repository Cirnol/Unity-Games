using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointCam : MonoBehaviour
{
    private Waypoint waypoint;

    public void SetWaypoint(Waypoint waypoint, bool done)
    {   
        if(this.waypoint == waypoint && done)
        {
            gameObject.SetActive(false);
            this.waypoint = null;
            return;
        }

        if (this.waypoint != null || waypoint == null)
            return;

        gameObject.SetActive(true);
        this.waypoint = waypoint;
        Vector3 pos = waypoint.transform.position;
        pos.z = -10;
        transform.position = pos;
    }
}
