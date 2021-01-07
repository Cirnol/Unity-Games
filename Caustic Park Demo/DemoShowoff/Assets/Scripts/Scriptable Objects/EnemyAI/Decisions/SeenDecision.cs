using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Enemy/Decisions/IsSeen")]
public class SeenDecision : Decision
{
    public override bool Decide(EnemyStateController controller)
    {
        return isSeen(controller);
    }

    private bool isSeen(EnemyStateController controller)
    {
        return controller.IsSeen();
    }
}
