using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaFollow : MonoBehaviour
{

    public GameObject player;
    public GameObject plasma;

    // Start is called before the first frame update
    void Start()
    {
        plasma.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, 0, 45);
    }

    void OnCollisionEnter2D(Collision2D otherThing)
    {
        if (otherThing.gameObject == player)
        {
            plasma.GetComponent<SpriteRenderer>().enabled = true;
            plasma.transform.right = plasma.transform.position - player.transform.position;
        }
    }

    void OnCollisionExit(Collision otherThing)
    {
        plasma.GetComponent<SpriteRenderer>().enabled = false; // Not working
    }
}
