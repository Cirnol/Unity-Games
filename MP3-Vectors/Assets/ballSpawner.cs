using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballSpawner : MonoBehaviour
{
    public GameObject ball;
    public GameObject epA;

    private float spawnX;
    private float spawnY;
    private float spawnZ;

    private float interval;

    // Start is called before the first frame update
    void Start()
    {
        spawnX = epA.transform.position.x;
        spawnY = epA.transform.position.y;
        spawnZ = epA.transform.position.z;

        interval = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        interval -= Time.deltaTime;

        if (interval <= 0)
        {
            Instantiate(ball, new Vector3(spawnX, spawnY, spawnZ), Quaternion.identity);
            interval = 1f;
        }

            
    }
}
