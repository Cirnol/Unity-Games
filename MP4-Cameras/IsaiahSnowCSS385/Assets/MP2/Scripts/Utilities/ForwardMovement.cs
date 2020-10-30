using UnityEngine;

public class ForwardMovement : MonoBehaviour
{

    public float Speed = 20;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if(!rb)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }

        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.gravityScale = 0;
    }

    void Update()
    {
        Vector3 forward = transform.up * Speed;
        rb.velocity = forward;
    }

    public void Stop()
    {
        rb.velocity = Vector3.zero;
    }
}
