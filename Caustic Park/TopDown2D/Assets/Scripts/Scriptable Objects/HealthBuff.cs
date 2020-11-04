using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerup Effects/Health Buff")]
public class HealthBuff : PowerupEffect
{
    public float amount;
    public override void Apply(GameObject collector)
    {
        collector.GetComponent<Health>().value += amount;
    }
}
