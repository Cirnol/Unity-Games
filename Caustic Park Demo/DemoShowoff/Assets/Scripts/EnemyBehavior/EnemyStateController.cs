using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Navigation))]
public class EnemyStateController : MonoBehaviour
{
    #region Instance Variables
    public State CurrentState;
    [HideInInspector] public FOV[] FoV;
    [HideInInspector] public Navigation NavAgent;
    [HideInInspector] public Transform HeroTransform;
    [HideInInspector] public Hero Hero;

    public EnemyStats Stats;

    [HideInInspector] public bool AttackedPlayer = false;
    [HideInInspector] public Vector3 LastWaypointLocation;
    [HideInInspector] public Vector3 PlayerLastLocation;
    [HideInInspector] public Vector3 FleeLocation;
    [HideInInspector] public Vector3 StartLocation { get; private set; }

    [HideInInspector] public float stateTimeElasped;

    private float playerLastSeenTimer = 0;
    public float lastAttackTimer = 0;
    private float lastSeenTimer = 0;
    private bool seen = false;
    #endregion

    #region Unity Methods
    private void Awake()
    {
        Hero = FindObjectOfType<Hero>();
        HeroTransform = Hero.gameObject.transform;
        FoV = GetComponentsInChildren<FOV>();
        NavAgent = GetComponent<Navigation>();
        playerLastSeenTimer = Stats.ChaseAfterLostTime;
        StartLocation = transform.position;
    }

    private void Start()
    {
        NavAgent.path.maxSpeed = Stats.MoveSpeed;
        CurrentState = Stats.StartingState;
        CurrentState.UpdateState(this);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CurrentState.UpdateState(this);
        setTimers();
        setPlayerLastPosition();
    }
    #endregion

    #region Public Methods
    public void TransitionToState(State nextState)
    {
        if(nextState != Stats.RemainState)
        {
            CurrentState.StopState(this);
            CurrentState = nextState;
            OnExitState();
        }
    }

    public bool CheckIfCountDownElapsed(float duration)
    {
        bool elapsed = stateTimeElasped >= duration;
        return elapsed;
    }

    public bool PlayerSeen()
    {
        if (playerLastSeenTimer < Stats.ChaseAfterLostTime)
        {
            return true;
        }
        return false;
    }

    public bool IsSeen()
    {
        if(lastSeenTimer > 0 || !seen)
        {
            return false;
        }
        return true;
    }

    public void Attack()
    {
        if(lastAttackTimer <= 0)
        {
            Hero.DealDamage(Stats.AttackDamage);
            AttackedPlayer = true;
        }
    }

    public void BatteryAttack()
    {
        if (lastAttackTimer <= 0)
        {
            FindObjectOfType<FlashlightController>().TakeDamage(Stats.BatteryAttackDamage);
            AttackedPlayer = true;
        }
    }

    public void SetWaypointLocation()
    {
        LastWaypointLocation = transform.position;
    }
    #endregion

    #region Private Methods
    private void setTimers()
    {
        bool playerSeen = false;

        foreach (FOV fov in FoV)
        {
            if (fov.IsPlayerSeen(HeroTransform))
                playerSeen = true;
        }

        if(!playerSeen)
        {
            playerLastSeenTimer += Time.fixedDeltaTime;
        }
        else
        {
            playerLastSeenTimer = 0;
        }

        if (lastAttackTimer > 0)
        {
            lastAttackTimer -= Time.fixedDeltaTime;
        }

        seen = Hero.fov.IsPlayerSeen(transform) || Hero.beamHandler.IsPlayerSeen(transform);

        if(seen && lastSeenTimer > 0)
        {
            lastSeenTimer -= Time.fixedDeltaTime;
        }
        else if(!seen)
        {
            lastSeenTimer = Stats.TimeForSeen;
        }

        if(AttackedPlayer)
        {
            lastAttackTimer = Stats.TimeBetweenAttacks;
            AttackedPlayer = false;
        }

        stateTimeElasped += Time.fixedDeltaTime;
    }

    private void setPlayerLastPosition()
    {
        bool playerSeen = false;

        foreach (FOV fov in FoV)
        {
            if (fov.IsPlayerSeen(HeroTransform))
                playerSeen = true;
        }

        if (playerSeen)
        {
            PlayerLastLocation = HeroTransform.position;
        }
    }

    private void OnExitState()
    {
        stateTimeElasped = 0;
        playerLastSeenTimer = Stats.ChaseAfterLostTime;
    }
    #endregion
}
