using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [Tooltip("Prefab to instantiate")]
    [SerializeField] private List<GameObject> prefabs;

    [Tooltip("Minimum count of objects at one time")]
    [SerializeField] private int min;

    private int count;

    private float height;
    private float width;

    private List<Enemy> enemies;
    private bool movement = true;

    public Enemy.movement currentMovement = Enemy.movement.waypoint_seq;

    private void Awake()
    {
        height = Camera.main.orthographicSize;
        float AspectRatio = Camera.main.aspect;
        width = height * AspectRatio;

        height *= .9f;
        width *= .9f;
        enemies = new List<Enemy>();
    }

    private void Update()
    {
        count = Enemy.GetEnemyCount();
        if(count < min)
        {
            enemies.Add(spawn().GetComponent<Enemy>());
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            currentMovement = getNextMovement();
            foreach (Enemy enemy in Enemy.enemies)
            {
                enemy.SwapMovement(currentMovement);
            }
        }
    }

    private Enemy.movement getNextMovement()
    {
        Enemy.movement move = Enemy.movement.wander;

        switch(currentMovement)
        {
            case Enemy.movement.wander:
                move = Enemy.movement.waypoint_seq;
                break;
            case Enemy.movement.waypoint_seq:
                move = Enemy.movement.waypoint_rand;
                break;
            case Enemy.movement.waypoint_rand:
                move = Enemy.movement.wander;
                break;
            default:
                move = Enemy.movement.waypoint_seq;
                break;
        }

        return move;
    }

    private GameObject spawn()
    {
        GameObject prefab = prefabs[UnityEngine.Random.Range(0, prefabs.Count)];
        GameObject enemy =  Instantiate(prefab, getNewPos(), Quaternion.identity);

        enemy.transform.parent = gameObject.transform;
        enemy.GetComponent<Enemy>().SwapMovement(currentMovement);
        return enemy;
    }

    private Vector2 getNewPos()
    {
        Vector2 newPos = new Vector2(UnityEngine.Random.Range(-width, width), UnityEngine.Random.Range(-height, height));
        return newPos;
    }

    public void ToggleMovement()
    {
        movement = !movement;
        foreach(Enemy enemy in enemies)
        {
            enemy.toggleWander();
        }
    }

    public void Remove(Enemy e)
    {
        if(e != null)
        {
            enemies.Remove(e);
        }
    }
}
