using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCam : MonoBehaviour
{
    private Enemy enemy;
    private Hero hero;
    private Camera cam;

    private void Awake()
    {
        hero = FindObjectOfType<Hero>();
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        if (enemy != null)
        {
            //Set size
            cam.orthographicSize = (hero.transform.position - enemy.transform.position).magnitude;

            //Set position
            Vector3 pos = (hero.transform.position + enemy.transform.position) * .5f;
            pos.z = -10;
            transform.position = pos;

            checkPos();
        }
        else if(gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }

        
    }

    private void checkPos()
    {
        if(Vector2.Distance(enemy.gameObject.transform.position, hero.gameObject.transform.position) > 40 || enemy.currentMovement != Enemy.movement.chase)
        {
            gameObject.SetActive(false);
            enemy = null;
        }
    }

    public void SetEnemy(Enemy enemy, bool done)
    {
        if (this.enemy == enemy && done)
        {
            gameObject.SetActive(false);
            this.enemy = null;
            return;
        }

        if (this.enemy != null || enemy == null)
            return;

        gameObject.SetActive(true);
        this.enemy = enemy;
    }
}
