using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Enemy/Actions/FollowPlayer")]
public class FollowPlayerAction : EnemyAction
{
    public override void Act(EnemyStateController controller)
    {
        MoveTowardsPlayer(controller);
    }

    public override void Stop(EnemyStateController controller)
    {

    }

    private void MoveTowardsPlayer(EnemyStateController controller)
    {
        Vector3 newPosition = controller.transform.position;
        Vector3 dir = (controller.HeroTransform.position - newPosition).normalized;
        newPosition = newPosition + (dir * controller.Stats.MoveSpeed * Time.fixedDeltaTime);

        controller.transform.position = newPosition;
        controller.transform.up = dir;
    }
}
