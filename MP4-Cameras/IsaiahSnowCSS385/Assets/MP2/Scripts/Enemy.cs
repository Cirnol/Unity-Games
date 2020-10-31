using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Enemy : MonoBehaviour
{

    static int EnemyCount = 0;
    static int EnemyDestroyed = 0;
    private int hitCount;

    private Renderer sprite;
    private Wander wander;
    private StunnedState stunnedState;
    private EggState eggState;

    private CCWState ccwState;
    private CWState cwState;
    private EnlargeState enlargeState;
    private ShrinkState shrinkState;
    private ChaseState chaseState;

    private WaypointMover waypoint;

    private Vector3 EggUp;

    public static List<Enemy> enemies = new List<Enemy>();

    public movement currentMovement;
    public movement storedMovement;

    public enum movement
    {
        wander,
        waypoint_seq,
        waypoint_rand,
        stunned_state,
        egg_state,
        CCW_Rotate,
        CW_Rotate,
        chase,
        enlarge,
        shrink
    }

    void Awake()
    {
        EnemyCount++;
        hitCount = 0;
        sprite = GetComponent<Renderer>();
        wander = GetComponent<Wander>();
        waypoint = GetComponent<WaypointMover>();
        stunnedState = GetComponent<StunnedState>();
        eggState = GetComponent<EggState>();
        ccwState = GetComponent<CCWState>();
        cwState = GetComponent<CWState>();
        chaseState = GetComponent<ChaseState>();
        enlargeState = GetComponent<EnlargeState>();
        shrinkState = GetComponent<ShrinkState>();

        gameObject.GetComponent<Animator>().Play("Idle");
        if (waypoint == null)
        {
            waypoint = gameObject.AddComponent<WaypointMover>();
        }

        enemies.Add(this);
    }

    private void OnDestroy()
    {
        EnemyManager em = FindObjectOfType<EnemyManager>();
        if(em)
        {
            em.Remove(this);
        }
        EnemyCount--;
        EnemyDestroyed++;
        enemies.Remove(this);
    }

    public void Hit(Vector3 eggUp)
    {
        //hitCount++;

        //if(hitCount >= 4)
        //{
        //    Destroy(gameObject);
        //}

        //Color newColor = sprite.material.color;
        //newColor.a = newColor.a * .8f;
        //sprite.material.color = newColor;
        EggUp = eggUp;

        if (currentMovement == movement.stunned_state)
        {
            SwapMovement(movement.egg_state);
        }
        else if (currentMovement == movement.egg_state)
        {
            Destroy(gameObject);
        }
        else
        { 
            SwapMovement(movement.stunned_state);
        }
        
    }

    public static int GetEnemyCount()
    {
        return EnemyCount;
    }

    public static int GetEnemyDestroyed()
    {
        return EnemyDestroyed;
    }

    public void toggleWander()
    {
        wander.enabled = !wander.enabled;
    }

    public void SwapMovement(movement movement)
    {
        currentMovement = movement;

        switch (currentMovement)
        {
            case movement.wander:
                deactivateMovement();
                waypoint.enabled = false;
                storedMovement = movement.wander;
                childOff();

                break;
            case movement.waypoint_seq:
                transform.GetComponent<SpriteRenderer>().color = Color.white;
                deactivateMovement();
                waypoint.enabled = true;
                waypoint.ToggleMovement(false);
                storedMovement = movement.waypoint_seq;
                childOn();
                break;
            case movement.waypoint_rand:
                transform.GetComponent<SpriteRenderer>().color = Color.white;
                deactivateMovement();
                waypoint.enabled = true;
                waypoint.ToggleMovement(true);
                storedMovement = movement.waypoint_rand;
                childOn();
                break;
            case movement.stunned_state:
                deactivateMovement();
                stunnedState.enabled = true;
                stunnedState.setEggUp(EggUp);
                stunnedState.setStartPos();
                childOff();
                break;
            case movement.egg_state:
                deactivateMovement();
                eggState.enabled = true;
                eggState.setEggUp(EggUp);
                eggState.setStartPos();
                childOff();
                break;
            case movement.CCW_Rotate:
                deactivateMovement();
                childOn();
                transform.GetComponent<SpriteRenderer>().color = Color.red;
                ccwState.enabled = true;
                ccwState.StartRotation();
                break;
            case movement.CW_Rotate:
                deactivateMovement();
                childOn();
                cwState.enabled = true;
                cwState.StartRotation();
                break;
            case movement.chase:
                deactivateMovement();
                childOn();
                chaseState.enabled = true;
                chaseState.StartChase(FindObjectOfType<Hero>());
                break;
            case movement.enlarge:
                deactivateMovement();
                childOn();
                enlargeState.enabled = true;
                enlargeState.Enlarge();
                break;
            case movement.shrink:
                deactivateMovement();
                childOn();
                shrinkState.enabled = true;
                shrinkState.Shrink();
                break;

        }
    }

    private void deactivateMovement()
    {
        wander.enabled = false;
        waypoint.enabled = false;
        stunnedState.enabled = false;
        eggState.enabled = false;
        ccwState.enabled = false;
        cwState.enabled = false;
        chaseState.enabled = false;
        enlargeState.enabled = false;
        shrinkState.enabled = false;
    }

    private void childOff()
    {
        for(int i = 0; i < gameObject.transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    private void childOn()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
