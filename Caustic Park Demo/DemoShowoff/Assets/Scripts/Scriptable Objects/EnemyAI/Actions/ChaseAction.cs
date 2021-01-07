using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Enemy/Actions/Chase")]
public class ChaseAction : EnemyAction
{
    public override void Act(EnemyStateController controller)
    {
        Chase(controller);
    }

    public override void Stop(EnemyStateController controller)
    {
        controller.NavAgent.Stop();
    }

    private void Chase(EnemyStateController controller)
    {
        controller.NavAgent.Chase(controller.HeroTransform);
    }
}
