using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Enemy/Decisions/StraighPath")]
public class StraightPathDecision : Decision
{
    public override bool Decide(EnemyStateController controller)
    {
        return closeToLocation(controller);
    }

    private bool closeToLocation(EnemyStateController controller)
    {
        Vector3 myPosition = controller.transform.position;
        Vector3 distance = controller.StartLocation - myPosition;

        if(distance.magnitude <= .5f)
        {
            return true;
        }
        return false;
    }
}
