using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheWorld : MonoBehaviour
{
    // puzzle types
    [SerializeField] bool SensorPuzzle;
    [SerializeField] bool heatPuzzle;
    [SerializeField] bool SequencePuzzle;

    // required objects
    public FOV fov = null;
    public BeamFOVHandler beamFov = null;
    public DoorBehavior door = null;
    public Hero hero = null;

    public AudioClip buttonSound;
    public AudioClip doorSound;

    //world dependent
    [SerializeField] bool beamOn;

    [SerializeField] bool dontClear;

    private System.Random random = new System.Random();

    //light sensor puzzle
    public List<buttonBehavior> buttons = null;
    public List<DoorLightBehavior> doorLights = null;
    public List<blacklightMessages> messages = null;
    private int activeButtonNum = 0;


    //heat sensor puzzle
    public List<ItemBehavior> items = null;

    void Start()
    {
        if(door != null)
        {
            door.enabled = false;
        }
        if(heatPuzzle)
        {
            int goodDrink = random.Next(0, items.Count-1);
            foreach (ItemBehavior item in items)
            {
                item.setDrink(true);
            }
            items[goodDrink].setDrink(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SensorPuzzle)
        {
            foreach (buttonBehavior button in buttons)
            {
                
                if (fov.showMesh)
                {
                    button.Seen(fov.IsInteractableSeen(button.transform));
                }
                else
                {
                    button.Seen(beamFov.IsInteractableSeen(button.transform));
                }

            }
            if (activeButtonNum == buttons.Count)
            {
                Debug.Log("opening Door");
                if (!door.enabled)
                {
                    GetComponent<AudioSource>().PlayOneShot(doorSound);
                }
                door.enabled = true;
            }
        }
        else if(heatPuzzle)
        {
            if (fov.bulb.power == Bulb.Power.HEAT)
            {
                foreach (ItemBehavior item in items)
                {
                    if (fov.showMesh)
                    {
                        item.Seen(fov.IsInteractableSeen(item.transform));
                    }
                    else
                    {
                        item.Seen(beamFov.IsInteractableSeen(item.transform));
                    }
                }

            }
            else
            {
                foreach (ItemBehavior item in items)
                {
                    item.Seen(false);
                }
            }
        }
        foreach(blacklightMessages message in messages)
        {
            message.Seen(fov.IsInteractableSeen(message.transform));
        }
        if(!dontClear)
        {
            beamFov.Clear();
        }

    }

    public void clicked(GameObject obj)
    {
        foreach (ItemBehavior item in items)
        {
            if(item.gameObject == obj)
            {
                item.clicked();
            }
        }
    }
    public void dealDamage(float damage)
    {
        hero.DealDamage(damage);
    }

    public void checkButton(int buttonNum)
    {
        if(buttonNum == activeButtonNum)
        {
            doorLights[activeButtonNum].turnOn();
            activeButtonNum++;
            playButtonActivatedSound();
        } else
        {
            wrongButton();
        }
    }

    public void wrongButton()
    {
        activeButtonNum = 0;
        foreach (buttonBehavior button in buttons)
        {
            button.undo();
        }
        foreach (DoorLightBehavior doorLight in doorLights)
        {
            doorLight.turnOff();
        }
        
    }

    public void drunk()
    {
        if (!door.enabled)
        {
            GetComponent<AudioSource>().PlayOneShot(doorSound);
        }
        door.enabled = true;
    }
    public void addActiveButton()
    {
        doorLights[activeButtonNum].turnOn();
        activeButtonNum++;
        playButtonActivatedSound();
    }

    private void playButtonActivatedSound() {
        if (activeButtonNum == buttons.Count)
        {
            //GetComponent<AudioSource>().PlayOneShot(doorSound);
        } else
        {
            GetComponent<AudioSource>().PlayOneShot(buttonSound);
        }
    }

    

    public Bulb getBulb()
    {
        return fov.bulb;
    }
}
