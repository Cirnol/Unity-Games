using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunnedState : MonoBehaviour
{
    private float timer = 0.0f;
    private float timeToStopLerping = 2.0f;
    private Vector3 mEggUp;
    private float roteSpeed = 1f;
    private Vector3 startPos;

    public void setEggUp(Vector3 eggUp)
    {
        mEggUp = eggUp;
    }
    public void setStartPos()
    {
        startPos = transform.localPosition;
    }
    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Animator>().Play("Stunned");
        // transform.GetComponent<SpriteRenderer>().color = Color.yellow;
        transform.position = Vector3.Lerp(transform.position, startPos + 4 * mEggUp, 0.05f);
        transform.Rotate(new Vector3(0, 0, -90) * Time.deltaTime * roteSpeed, Space.World);
    }
}
