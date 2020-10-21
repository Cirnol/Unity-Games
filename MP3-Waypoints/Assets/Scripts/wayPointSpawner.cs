using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static waypointBehavior;

public class wayPointSpawner : MonoBehaviour
{
    public GameObject waypoint;

    private float startPosX;
    private float startPosY;
    private float ranX;
    private float ranY;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (waypointMissing)
        {
            Debug.Log("Missing Waypoint!");

            if (whichWaypoint == 1)
            {
                ranX = Random.Range(-15, 15);
                ranY = Random.Range(-15, 15);
                GameObject unnamedWay = Instantiate(waypoint, new Vector2((spawnPosX + ranX), (spawnPosY + ranY)), Quaternion.identity);
                unnamedWay.name = "WPA";
                waypointMissing = false;
            }

            if (whichWaypoint == 2)
            {
                ranX = Random.Range(-15, 15);
                ranY = Random.Range(-15, 15);
                GameObject unnamedWay = Instantiate(waypoint, new Vector2((spawnPosX + ranX), (spawnPosY + ranY)), Quaternion.identity);
                unnamedWay.name = "WPB";
                waypointMissing = false;
            }

            if (whichWaypoint == 3)
            {
                ranX = Random.Range(-15, 15);
                ranY = Random.Range(-15, 15);
                GameObject unnamedWay = Instantiate(waypoint, new Vector2((spawnPosX + ranX), (spawnPosY + ranY)), Quaternion.identity);
                unnamedWay.name = "WPC";
                waypointMissing = false;
            }

            if (whichWaypoint == 4)
            {
                ranX = Random.Range(-15, 15);
                ranY = Random.Range(-15, 15);
                GameObject unnamedWay = Instantiate(waypoint, new Vector2((spawnPosX + ranX), (spawnPosY + ranY)), Quaternion.identity);
                unnamedWay.name = "WPD";
                waypointMissing = false;
            }

            if (whichWaypoint == 5)
            {
                ranX = Random.Range(-15, 15);
                ranY = Random.Range(-15, 15);
                GameObject unnamedWay = Instantiate(waypoint, new Vector2((spawnPosX + ranX), (spawnPosY + ranY)), Quaternion.identity);
                unnamedWay.name = "WPE";
                waypointMissing = false;
            }

            if (whichWaypoint == 6)
            {
                ranX = Random.Range(-15, 15);
                ranY = Random.Range(-15, 15);
                GameObject unnamedWay = Instantiate(waypoint, new Vector2((spawnPosX + ranX), (spawnPosY + ranY)), Quaternion.identity);
                unnamedWay.name = "WPF";
                waypointMissing = false;
            }
        }
    }
}
