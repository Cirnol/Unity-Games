using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyStatus : MonoBehaviour
{
    private Text text;
    private EnemyManager manager;
    private Enemy.movement movement;

    private void Awake()
    {
        text = GetComponent<Text>();
        manager = FindObjectOfType<EnemyManager>();
    }

    private void Update()
    {
        movement = manager.currentMovement;
        string mov = "";
        switch (movement)
        {
            case Enemy.movement.wander:
                mov = "Wander";
                break;
            case Enemy.movement.waypoint_rand:
                mov = "Waypoint Rand";
                break;
            case Enemy.movement.waypoint_seq:
                mov = "Waypoint Seq";
                break;
        }
        if(SceneManager.GetActiveScene().buildIndex > 2)
            text.text = "Movement: " + mov + "\nEnemy Count: " + Enemy.GetEnemyCount() + "\nEnemies Destroyed: " + Enemy.GetEnemyDestroyed();
        else
            text.text = "Enemy Count: " + Enemy.GetEnemyCount() + "\nEnemies Destroyed: " + Enemy.GetEnemyDestroyed();
    }
}
