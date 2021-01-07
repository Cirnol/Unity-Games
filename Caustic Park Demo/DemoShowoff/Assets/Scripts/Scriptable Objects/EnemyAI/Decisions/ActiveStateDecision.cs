using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Enemy/Decisions/ActiveState")]
public class ActiveStateDecision : Decision
{
    public override bool Decide(EnemyStateController controller)
    {
        bool chaseTargetIsActive = controller.HeroTransform.gameObject.activeSelf;
        return chaseTargetIsActive;
    }
}
