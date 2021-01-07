using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Enemy/Actions/Suck")]
public class SuckAction : EnemyAction
{
    public override void Act(EnemyStateController controller)
    {
        Suck(controller);
    }

    public override void Stop(EnemyStateController controller)
    {

    }

    private void Suck(EnemyStateController controller)
    {
        bool playerLooking = controller.IsSeen();
        if(playerLooking)
        {
            Vector3 newPos = controller.HeroTransform.position;
            Vector3 dir = controller.transform.position - newPos;

            controller.Hero.GetComponent<Rigidbody2D>().AddForce(dir.normalized * 375f, ForceMode2D.Force);
        }
    }
}
