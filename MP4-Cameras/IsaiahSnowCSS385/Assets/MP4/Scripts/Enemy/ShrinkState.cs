using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkState : MonoBehaviour
{
    private Enemy enemy;
    private int counter;
    private bool shrinking;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    void Update()
    {
        if (counter < 60 && shrinking)
        {
            transform.localScale = transform.localScale - new Vector3(2f / 60f, 2f / 60f);
            counter++;
            if (counter >= 60)
            {
                shrinking = false;
                enemy.SwapMovement(enemy.storedMovement);
            }
        }
    }

    public void Shrink()
    {
        counter = 0;
        shrinking = true;
    }

    public bool IsTurning()
    {
        return shrinking;
    }
}
