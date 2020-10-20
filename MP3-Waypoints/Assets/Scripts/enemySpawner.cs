using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static enemyCount;
using static waypointBehavior;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject waypoint;
    private GameObject unnamedWay;

    private float northLimit;
    private float southLimit;
    private float westLimit;
    private float eastLimit;

    private float ranX;
    private float ranY;

    private bool canRespawn;

    // Start is called before the first frame update
    void Start()
    {
        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));
        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        northLimit = topCorner.y;
        southLimit = bottomCorner.y;
        westLimit = bottomCorner.x;
        eastLimit = topCorner.x;

        canRespawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (eCounter < 10)
        {
            eCounter += 1;
            ranX = Random.Range(westLimit * 0.9f, eastLimit * 0.9f);
            ranY = Random.Range(northLimit * 0.9f, southLimit * 0.9f);
            Instantiate(enemy, new Vector2(ranX, ranY), Quaternion.identity);
        }

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
