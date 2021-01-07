using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Decisions/Look")]
public class LookDecision : Decision
{
    public override bool Decide(EnemyStateController controller)
    {
        bool playerVisible = Look(controller);
        return playerVisible;
    }

    private bool Look(EnemyStateController controller)
    {
        bool playerSeen = controller.PlayerSeen();
        return playerSeen;
    }
}
