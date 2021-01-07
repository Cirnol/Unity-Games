using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Enemy/Stats")]
public class EnemyStats : ScriptableObject
{
    public State StartingState;
    public State RemainState;
    public float AttackRange;
    public float AttackDamage;
    public float BatteryAttackDamage;
    public float TimeBetweenAttacks;
    public float SearchRotationSpeed;
    public float SearchDuration;
    public float ChaseAfterLostTime;
    public float MoveSpeed;
    public float TimeForSeen;
    public float WaitTime;
}
