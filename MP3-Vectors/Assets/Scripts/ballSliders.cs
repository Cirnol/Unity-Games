using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ballSliders : MonoBehaviour
{
    public GameObject ball;
    public GameObject epA;

    private float spawnX;
    private float spawnY;
    private float spawnZ;

    private float interval;
    private float intervalEcho;
    public static float setSpeed;
    public static float lifeSpan;

    public Slider intervalSlider;
    public Slider speedSlider;
    public Slider lifeSlider;

    // Start is called before the first frame update
    void Start()
    {
        interval = 1f;
        intervalEcho = 0f;
        setSpeed = 15f;
        lifeSpan = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        // Obtain Endpoint A coordinates
        spawnX = epA.transform.position.x;
        spawnY = epA.transform.position.y;
        spawnZ = epA.transform.position.z;

        // Interval
        if(intervalEcho == intervalSlider.value)
        {
            interval -= Time.deltaTime;

            if (interval <= 0)
            {
                Instantiate(ball, new Vector3(spawnX, spawnY, spawnZ), Quaternion.identity);
                interval = intervalEcho;
            }
        }
        else
        {
            intervalEcho = intervalSlider.value;
            interval = intervalEcho;
        }

        setSpeed = speedSlider.value;
        lifeSpan = lifeSlider.value;
    }
}
