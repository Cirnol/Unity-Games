using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : MonoBehaviour
{
    private Hero hero;
    private Enemy enemy;
    private bool chasing;
    [SerializeField] private Globals global;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        if(chasing)
        {
            Vector2 dir = (hero.transform.position - transform.position).normalized;
            transform.up = dir;
            transform.position += transform.up * Time.deltaTime * 5;

            checkDistance();
        }
    }

    public void StartChase(Hero hero)
    {
        this.hero = hero;
        chasing = true;
        global.enemyCam.SetEnemy(enemy, false);
    }

    public void Clear()
    {
        global.enemyCam.SetEnemy(enemy, true);
    }

    private void checkDistance()
    {
        if(Vector3.Distance(transform.position, hero.transform.position) > 40)
        {
            hero = null;
            chasing = false;
            global.enemyCam.SetEnemy(enemy, true);
            enemy.SwapMovement(Enemy.movement.enlarge);
        }
    }
}
