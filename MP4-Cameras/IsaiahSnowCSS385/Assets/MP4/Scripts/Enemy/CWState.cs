using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CWState : MonoBehaviour
{
    private Enemy enemy;
    private int counter;
    private bool turning;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    void Update()
    {
        if(counter < 60 && turning)
        {
            transform.Rotate(new Vector3(0, 0, -90.0f/60.0f));
            counter++;
            if(counter >= 60)
            {
                turning = false;
                enemy.SwapMovement(Enemy.movement.chase);
            }
        }
    }

    public void StartRotation()
    {
        counter = 0;
        turning = true;
    }

    public bool IsTurning()
    {
        return turning;
    }
}
