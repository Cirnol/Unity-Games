using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static enemyCount;

public class enemyBehavior : MonoBehaviour
{
    private int health;
    private float alphaMat;
    public static int playerCheck;
    public static int destroyedEnemies;

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
            destroyedEnemies += 1;
            eCounter -= 1;
        }
    }

    void OnCollisionEnter2D(Collision2D otherThing)
    {
        if (otherThing.gameObject.tag == "Bolt")
        {
            health -= 1;
            alphaMat *= .8f;
            this.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, alphaMat);
        }

        if (otherThing.gameObject.tag == "Player")
        {
            playerCheck += 1;
            health = 0;
        }
    }
}
