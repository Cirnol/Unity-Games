using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Enemy/Actions/Investigate")]
public class InvestigateAction : EnemyAction
{
    public override void Act(EnemyStateController controller)
    {
        SetLocation(controller);
    }

    public override void Stop(EnemyStateController controller)
    {
        controller.NavAgent.Stop();
    }

    private void SetLocation(EnemyStateController controller)
    {
        controller.NavAgent.SetTarget(controller.PlayerLastLocation);
    }
}
