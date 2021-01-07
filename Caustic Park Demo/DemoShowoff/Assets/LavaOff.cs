using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaOff : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Child")
        {
            GetComponent<Collider2D>().enabled = false;
            gameObject.SetActive(false);
        }
    }
}
