using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Enemy/Decisions/LocationReached")]
public class ReachedDestinationDecision : Decision
{
    public override bool Decide(EnemyStateController controller)
    {
        bool finishedInvestigation = ReachedLocation(controller);
        return finishedInvestigation;
    }

    private bool ReachedLocation(EnemyStateController controller)
    {
        bool locationReached = controller.NavAgent.ReachedTarget() || controller.NavAgent.StalePath();
        return locationReached;
    }
}
