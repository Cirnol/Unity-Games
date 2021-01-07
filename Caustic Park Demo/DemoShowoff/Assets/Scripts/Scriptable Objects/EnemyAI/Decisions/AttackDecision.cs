using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Enemy/Decisions/Attacked")]
public class AttackDecision : Decision
{
    public override bool Decide(EnemyStateController controller)
    {
        bool enemyAttacked = DidEnemyAttackLastFrame(controller);
        return enemyAttacked;
    }

    private bool DidEnemyAttackLastFrame(EnemyStateController controller)
    {
        bool enemyAttackedPlayer = controller.AttackedPlayer;
        return enemyAttackedPlayer;
    }
}
