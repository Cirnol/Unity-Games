using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Enemy/Decisions/Wait")]
public class WaitDecision : Decision
{
    public override bool Decide(EnemyStateController controller)
    {
        return Wait(controller);
    }

    public bool Wait(EnemyStateController controller)
    {
        bool isWaitOver = controller.CheckIfCountDownElapsed(controller.Stats.WaitTime);
        return isWaitOver;
    }
}
