using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static enemyCount;

public class enemyBehavior : MonoBehaviour
{
    private int health;
    private float alphaMat;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Enemy Created");
        health = 4;
        alphaMat = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
            eCounter -= 1;
            Debug.Log("Enemy Destroyed");
        }
    }

    void OnCollisionEnter2D(Collision2D otherThing)
    {
        if (otherThing.gameObject.tag == "Bolt")
        {
            health -= 1;
            alphaMat *= .8f;
            this.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, alphaMat);
            Debug.Log("Current Health:" + health);
        }

        if (otherThing.gameObject.tag == "Player")
        {
            health = 0;
        }
    }
}
