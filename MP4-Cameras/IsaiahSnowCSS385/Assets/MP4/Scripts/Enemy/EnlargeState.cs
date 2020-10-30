using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnlargeState : MonoBehaviour
{
    private Enemy enemy;
    private int counter;
    private bool enlarging;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    void Update()
    {
        if (counter < 60 && enlarging)
        {
            transform.localScale = transform.localScale + new Vector3(2f/60f, 2f/60f);
            counter++;
            if (counter >= 60)
            {
                enlarging = false;
                enemy.SwapMovement(Enemy.movement.shrink);
            }
        }
    }

    public void Enlarge()
    {
        counter = 0;
        enlarging = true;
    }

    public bool IsTurning()
    {
        return enlarging;
    }
}
