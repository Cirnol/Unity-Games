using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunnedState : MonoBehaviour
{
    private float timer = 0.0f;
    private float timeToStopLerping = 2.0f;
    private Vector3 mEggUp;
    private float roteSpeed = 1f;

    public void setEggUp(Vector3 eggUp)
    {
        mEggUp = eggUp;
    }
    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Animator>().Play("Stunned");
        // transform.GetComponent<SpriteRenderer>().color = Color.yellow;
        transform.Rotate(new Vector3(0, 0, -90) * Time.deltaTime * roteSpeed, Space.World);
    }
}
