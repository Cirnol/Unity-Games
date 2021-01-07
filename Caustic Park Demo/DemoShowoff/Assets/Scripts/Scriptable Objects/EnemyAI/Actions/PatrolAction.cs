using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Actions/Patrol")]
public class PatrolAction : EnemyAction
{
    public override void Act(EnemyStateController controller)
    {
        Patrol(controller);
    }

    public override void Stop(EnemyStateController controller)
    {
        controller.NavAgent.Stop();
    }

    private void Patrol(EnemyStateController controller)
    {
        controller.NavAgent.Resume();

        if(controller.NavAgent.path.reachedDestination)
        {
            controller.NavAgent.waypointIndex = (controller.NavAgent.waypointIndex + 1) % controller.NavAgent.waypoints.waypoints.Count;
            controller.NavAgent.NextWaypoint();
        }

        controller.SetWaypointLocation();
    }
}
