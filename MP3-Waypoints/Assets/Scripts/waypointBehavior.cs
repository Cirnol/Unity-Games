using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypointBehavior : MonoBehaviour
{
    private float startPosX;
    private float startPosY;
    private float ranX;
    private float ranY;

    private int health;
    private float alphaMat;
    private bool toggleHide;

    // Start is called before the first frame update
    void Start()
    {
        startPosX = gameObject.transform.position.x;
        startPosY = gameObject.transform.position.y;

        health = 4;
        alphaMat = 1;
        toggleHide = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            ranX = Random.Range(-15, 15);
            ranY = Random.Range(-15, 15);
            gameObject.transform.position = new Vector3((startPosX + ranX), (startPosY + ranY), 0);
            alphaMat = 1;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, alphaMat);
            health = 4;
        }

        if (Input.GetKeyDown(KeyCode.H))
            toggleHide = !toggleHide;

        if (toggleHide)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }

    }
    void OnCollisionEnter2D(Collision2D otherThing)
    {
        if (otherThing.gameObject.tag == "Bolt")
        {
            health -= 1;
            alphaMat -= 0.25f;
            this.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, alphaMat);
            //gameObject.GetComponent<Animator>().Play("Eating");
        }
    }
}