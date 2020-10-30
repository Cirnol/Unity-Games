using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSystem : MonoBehaviour
{
    public List<GameObject> waypoints;

    public void ToggleVisibility()
    {
        foreach (GameObject point in waypoints)
        {
            Renderer r = point.GetComponent<Renderer>();
            r.enabled = !r.enabled;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            ToggleVisibility();
        }
    }
}
