using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerup Effects/InstaKill")]
public class InstaKill : PowerupEffect
{
    public override void Apply(GameObject collector)
    {
        Destroy(collector);
    }
}
