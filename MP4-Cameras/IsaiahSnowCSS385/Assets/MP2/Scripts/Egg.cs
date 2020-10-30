using UnityEngine;

public class Egg : MonoBehaviour
{
    private ForwardMovement move;

    private static int EggCount = 0;

    void Awake()
    {
        init();

        EggCount++;
    }

    private void OnDestroy()
    {
        EggCount--;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            collision.gameObject.GetComponent<Enemy>().Hit(transform.up);
            Destroy(gameObject);
        }
    }

    public void SetSpeed(float speed)
    {
        if(speed < 0)
        {
            speed = 0;
        }    
        move.Speed = speed + 40;
    }

    public static int GetEggCount()
    {
        return EggCount;
    }

    private void init()
    {
        move = GetComponent<ForwardMovement>();
        if (!move)
        {
            move = gameObject.AddComponent<ForwardMovement>();
        }

        move.Speed = 40;

        gameObject.AddComponent<Cleaner>();
    }
}
