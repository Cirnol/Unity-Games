using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBehavior : MonoBehaviour
{
    [SerializeField] float damage;
    public TheWorld theWorld = null;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        theWorld.dealDamage(damage);
    }
}
