using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Enemy/Actions/StraightPath")]
public class StraightPathAction : EnemyAction
{
    public override void Act(EnemyStateController controller)
    {
        moveToStartPosition(controller);
    }

    public override void Stop(EnemyStateController controller)
    {

    }

    private void moveToStartPosition(EnemyStateController controller)
    {
        Vector3 targetLocation = controller.StartLocation;
        Vector3 newPosition = controller.transform.position;
        Vector3 dir = (targetLocation - newPosition).normalized;

        controller.transform.position = newPosition + dir * controller.Stats.MoveSpeed * Time.fixedDeltaTime;
        controller.transform.up = dir;
    }
}
