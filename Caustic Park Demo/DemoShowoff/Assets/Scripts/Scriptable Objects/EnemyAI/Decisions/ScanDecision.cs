using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Enemy/Decisions/Scan")]
public class ScanDecision : Decision
{
    public override bool Decide(EnemyStateController controller)
    {
        bool noEnemyInSight = Scan(controller);
        return noEnemyInSight;
    }

    private bool Scan(EnemyStateController controller)
    {
        controller.NavAgent.Stop();
        controller.transform.Rotate(0, 0, controller.Stats.SearchRotationSpeed * Time.deltaTime);
        return controller.CheckIfCountDownElapsed(controller.Stats.SearchDuration);
    }
}
