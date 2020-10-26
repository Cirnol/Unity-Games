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

    public static float interval;

    public Slider intervalSlider;
    public Slider speedSlider;
    public Slider lifeSlider;

    public static float intervalEcho;
    private float speedEcho;
    private float lifeEcho;

    // Start is called before the first frame update
    void Start()
    {
        intervalEcho = 0f;
        interval = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        spawnX = epA.transform.position.x;
        spawnY = epA.transform.position.y;
        spawnZ = epA.transform.position.z;

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
    }
}
