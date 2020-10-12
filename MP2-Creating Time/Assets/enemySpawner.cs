using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static enemyCount;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemy;

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

        //for (int i = 0; i < 10; i++)
        //{
        //    Instantiate(enemy, new Vector3(ranX, ranY, 0), transform.rotation);
        //    eCounter += 1;
        //    Debug.Log("Enemies:" + eCounter);
        //    Debug.Log("i:" + i);

        //    if (i == 9)
        //    {
        //        canRespawn = true;
        //        Debug.Log("Respawn?" + canRespawn);
        //    }
        //}
    }

    // Update is called once per frame
    void Update()
    {  
        if (eCounter < 10)
        {
            ranX = Random.Range(westLimit * 0.9f, eastLimit * 0.9f);
            ranY = Random.Range(northLimit * 0.9f, southLimit * 0.9f);
            Instantiate(enemy, new Vector2(ranX, ranY), Quaternion.identity);
            eCounter += 1;
        }
    }
}
