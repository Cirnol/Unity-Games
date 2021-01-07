using UnityEngine;

public abstract class EnemyAction : ScriptableObject
{
    public abstract void Act(EnemyStateController controller);

    public abstract void Stop(EnemyStateController controller);
}
