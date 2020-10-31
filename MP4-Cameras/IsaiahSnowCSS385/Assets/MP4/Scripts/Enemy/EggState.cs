using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggState : MonoBehaviour
{
    private float timer = 0.0f;
    private float timeToStopLerping = 2.0f;
    private Vector3 mEggUp;
    private Vector3 startPos;

    public void setEggUp(Vector3 eggUp)
    {
        mEggUp = eggUp;
    }
    public void setStartPos()
    {
        startPos = transform.localPosition;
    }
    void Update()
    {
        gameObject.GetComponent<Animator>().Play("Egg");
        transform.position = Vector3.Lerp(transform.position, startPos + 8 * mEggUp, 0.05f);
    }

}
