using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static heroMovement;
using static eggBehavior;
using static enemyBehavior;
using static enemyCount;
using static toggleSequence;

public class textBehavior : MonoBehaviour
{
    public GameObject heroText;
    public GameObject eggText;
    public GameObject enemyText;
    public GameObject waypointText;

    Text thisText;

    private int currentEggs;
    private int currentEnemies;
    //private bool sequence;

    // Start is called before the first frame update
    void Start()
    {
        currentEggs = 0;
        currentEnemies = 0;
        //sequence = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Hero Stuff
        if (mouseCheck)
        {
            thisText = heroText.GetComponent<Text>();
            thisText.text = "HERO: Drive(Mouse) Touched Ghosts(" + playerCheck + ")";
        }
        else
        {
            thisText = heroText.GetComponent<Text>();
            thisText.text = "HERO: Drive(Key) Touched Ghosts(" + playerCheck + ")";
        }


        // Egg Stuff
        if(eggsVisible > currentEggs)
        {
            thisText = eggText.GetComponent<Text>();
            thisText.text = "ORBS: OnScreen(" + eggsVisible + ")";
            currentEggs += 1;
        }

        if (eggsVisible < currentEggs)
        {
            thisText = eggText.GetComponent<Text>();
            thisText.text = "ORBS: OnScreen(" + eggsVisible + ")";
            currentEggs -= 1;
        }

        // Enemy Stuff
        if (destroyedEnemies > currentEnemies && eCounter == 10)
        {
            thisText = enemyText.GetComponent<Text>();
            currentEnemies += 1;
            thisText.text = "GHOSTS: Count(" + eCounter + ") Destroyed(" + destroyedEnemies + ")";
        }

        // Waypoint Mode
        if (sequential)
        {
            thisText = waypointText.GetComponent<Text>();
            thisText.text = "Waypoints: (Sequence)";
        }
        else
        {
            thisText = waypointText.GetComponent<Text>();
            thisText.text = "Waypoints: (Random)";
        }

    }
}
