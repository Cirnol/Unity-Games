using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutoutNotify : MonoBehaviour
{
    private CutoutDisplay display;
    // Start is called before the first frame update
    void Start()
    {
        display = GameObject.FindObjectOfType<CutoutDisplay>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("im Hit!");
        if(collision.gameObject.name == "Child")
        {
            display.addCutout(gameObject);
        }
    }
}
