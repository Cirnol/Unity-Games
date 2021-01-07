using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Enemy/Actions/BatteryAttack")]
public class BatteryAttackAction : EnemyAction
{
    public override void Act(EnemyStateController controller)
    {
        Attack(controller);
    }

    public override void Stop(EnemyStateController controller)
    {
    }
    private void Attack(EnemyStateController controller)
    {
        if (controller.PlayerSeen() && Vector2.Distance(controller.transform.position, controller.HeroTransform.position) < controller.Stats.AttackRange)
        {
            controller.BatteryAttack();
        }
    }
}
