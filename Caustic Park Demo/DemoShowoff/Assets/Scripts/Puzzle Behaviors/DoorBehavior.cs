using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    private float timer = 0.0f;
    private float maxTime = 1.0f;
    //private void Start()
    //{
    //    gameObject.GetComponent<BoxCollider2D>().enabled = false;
    //}
    private void Update()
    {
        gameObject.SetActive(false);
        //gameObject.GetComponent<BoxCollider2D>().enabled = false;
        //gameObject.GetComponent<SpriteRenderer>().enabled = false;
        //timer += Time.deltaTime;
        //if (timer < maxTime)
        //{
        //    Vector3 temp = transform.position;
        //    temp.y -= 2 * Time.deltaTime;
        //    transform.position = temp;
        //} else
        //{
        //    gameObject.GetComponent<SpriteRenderer>().enabled = false;
        //}
    }
}
