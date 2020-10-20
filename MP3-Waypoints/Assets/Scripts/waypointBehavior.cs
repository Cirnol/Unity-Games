using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypointBehavior : MonoBehaviour
{
    public Sprite a;
    public Sprite b;
    public Sprite c;
    public Sprite d;
    public Sprite e;
    public Sprite f;

    private float startPosX;
    private float startPosY;
    public static float spawnPosX;
    public static float spawnPosY;

    private int health;
    private float alphaMat;

    public static bool waypointMissing;
    public static int whichWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "WPA")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = a;
            startPosX = -70;
            startPosY = 70;
        }

        if (gameObject.name == "WPB")
            gameObject.GetComponent<SpriteRenderer>().sprite = b;

        if (gameObject.name == "WPC")
            gameObject.GetComponent<SpriteRenderer>().sprite = c;

        if (gameObject.name == "WPD")
            gameObject.GetComponent<SpriteRenderer>().sprite = d;

        if (gameObject.name == "WPE")
            gameObject.GetComponent<SpriteRenderer>().sprite = e;

        if (gameObject.name == "WPF")
            gameObject.GetComponent<SpriteRenderer>().sprite = f;

        health = 3;
        alphaMat = 1;
        waypointMissing = false;
        whichWaypoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Debug.Log("Defeated Waypoint!");

            spawnPosX = startPosX;
            spawnPosY = startPosY;
            waypointMissing = true;

            if (gameObject.name == "WPA")
                whichWaypoint = 1;

            if (gameObject.name == "WPB")
                whichWaypoint = 2;

            if (gameObject.name == "WPC")
                whichWaypoint = 3;

            if (gameObject.name == "WPD")
                whichWaypoint = 4;

            if (gameObject.name == "WPE")
                whichWaypoint = 5;

            if (gameObject.name == "WPF")
                whichWaypoint = 6;

            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D otherThing)
    {
        if (otherThing.gameObject.tag == "Bolt")
        {
            Debug.Log("Ouchie Waypoint!");
            health -= 1;
            alphaMat -= 0.25f;
            this.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, alphaMat);
            //gameObject.GetComponent<Animator>().Play("Eating");
        }
    }
}
