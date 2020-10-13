using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static heroMovement;
using static eggBehavior;
using static enemyBehavior;
using static enemyCount;

public class textBehavior : MonoBehaviour
{
    public GameObject heroText;
    public GameObject eggText;
    public GameObject enemyText;

    Text thisText;

    private int currentEggs;
    private int currentEnemies;

    // Start is called before the first frame update
    void Start()
    {
        currentEggs = 0;
        currentEnemies = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Hero Stuff
        if (mouseCheck)
        {
            thisText = heroText.GetComponent<Text>();
            thisText.text = "HERO: Drive(Mouse) Touched Enemy(" + playerCheck + ")";
        }
        else
        {
            thisText = heroText.GetComponent<Text>();
            thisText.text = "HERO: Drive(Key) Touched Enemy(" + playerCheck + ")";
        }


        // Egg Stuff
        if(eggsVisible > currentEggs)
        {
            thisText = eggText.GetComponent<Text>();
            thisText.text = "EGG: OnScreen(" + eggsVisible + ")";
            currentEggs += 1;
        }

        if (eggsVisible < currentEggs)
        {
            thisText = eggText.GetComponent<Text>();
            thisText.text = "EGG: OnScreen(" + eggsVisible + ")";
            currentEggs -= 1;
        }

        // Enemy Stuff
        if (destroyedEnemies > currentEnemies && eCounter == 10)
        {
            thisText = enemyText.GetComponent<Text>();
            currentEnemies += 1;
            thisText.text = "ENEMY: Count(" + eCounter + ") Destroyed(" + destroyedEnemies + ")";
        }

    }
}
