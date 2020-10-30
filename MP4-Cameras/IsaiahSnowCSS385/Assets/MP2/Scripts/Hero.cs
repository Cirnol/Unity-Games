using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {

    [SerializeField] private float speed;
    [SerializeField] private float angleSpeed;

    [SerializeField] private GameObject eggPrefab;

    [SerializeField] private List<Transform> spawns;
    [SerializeField] private AudioSource sound;

    public string Controls;
    public int EnemyTouched;
    public int EnemyHit;

    private ScreenWrap wrap;
    private SpriteAnimator flames;
    private ForwardMovement move;
    private MouseMovement mouse;
    private Rotator rotate;

    private float fireTimer;
    public float fireBar;

    public HeroCam heroCam;

    private bool MouseMovement = false;

    void Awake()
    {
        init();
        setInput();
        EnemyTouched = 0;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            setInput();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (fireTimer <= 0)
            {
                fire();
                fireTimer = .2f;
            }
        }

        if (move.enabled)
        {
            speed += Input.GetAxis("Vertical") * Time.deltaTime * 150;
            
            if(speed > 150)
            {
                speed = 150;
            }
            if(speed < 20)
            {
                speed = 20;
            }

            move.Speed = speed;
        }

        if(fireTimer > 0)
        {
            fireTimer -= Time.deltaTime;
            fireBar = fireTimer * 5;
            if(fireTimer < 0)
            {
                fireTimer = 0;
                fireBar = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy.currentMovement == Enemy.movement.chase)
            {
                EnemyHit++;
                Destroy(collision.gameObject);
            }
            else if(enemy.currentMovement == Enemy.movement.waypoint_seq || enemy.currentMovement == Enemy.movement.waypoint_rand)
            {
                EnemyTouched++;
                enemy.SwapMovement(Enemy.movement.CCW_Rotate);
            } 
            else
            {
                EnemyTouched++;
            }
        }
    }

    private void init()
    {
        wrap = GetComponent<ScreenWrap>();
        if (!wrap)
        {
            wrap = gameObject.AddComponent<ScreenWrap>();
        }

        move = GetComponent<ForwardMovement>();
        if(!move)
        {
            move = gameObject.AddComponent<ForwardMovement>();
        }
        move.Speed = speed;

        rotate = GetComponent<Rotator>();
        if(!rotate)
        {
            rotate = gameObject.AddComponent<Rotator>();
        }

        rotate.deltaAngle = angleSpeed;

        mouse = GetComponent<MouseMovement>();
        if(!mouse)
        {
            mouse = gameObject.AddComponent<MouseMovement>();
        }

        sound = GetComponent<AudioSource>();
        flames = GetComponentInChildren<SpriteAnimator>();

    }

    private void fire()
    {
        sound.Play();

        foreach (Transform spawn in spawns)
        {
            Egg spawned = Instantiate(eggPrefab, spawn.position, transform.rotation).GetComponent<Egg>();
            spawned.SetSpeed(speed);
        }
        heroCam.Shake();
    }

    private void setInput()
    {
        MouseMovement = !MouseMovement;
        if(MouseMovement)
        {
            move.Stop();
            move.enabled = false;
            wrap.enabled = false;
            mouse.enabled = true;
            Controls = "Mouse";
            flames.gameObject.SetActive(false);
            flames.enabled = false;
        }
        else
        {
            mouse.enabled = false;
            wrap.enabled = true;
            move.enabled = true;
            Controls = "Keyboard";
            flames.gameObject.SetActive(true);
            flames.enabled = true;
        }
    }
}
