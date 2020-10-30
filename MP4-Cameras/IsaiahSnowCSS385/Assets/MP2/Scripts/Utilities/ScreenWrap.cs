using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ScreenWrap : MonoBehaviour
{

    private bool wrapX = false;
    private bool wrapY = false;

    private float height;
    private float width;

    private Renderer sprite;

    private float timer;

    void Awake()
    {
        height = Camera.main.orthographicSize;
        float AspectRatio = Camera.main.aspect;
        width = height * AspectRatio;

        sprite = GetComponent<Renderer>();
    }

    void Update()
    {
        CheckWrap();
    }

    private void CheckWrap()
    {
        if (sprite.isVisible)
        {
            wrapX = false;
            wrapY = false;
            timer = 5;
            return;
        }

        timer -= Time.deltaTime;

        if(timer < 0)
        {
            transform.position = new Vector3(0, 0, 0);
        }

        if (wrapX && wrapY)
        {
            return;
        }

        Vector3 newPos = transform.position;

        if ((newPos.x > width || newPos.x < -width) && !wrapX)
        {
            newPos.x = -newPos.x;
            wrapX = true;
        }

        if ((newPos.y > height || newPos.y < -height) && !wrapY)
        {
            newPos.y = -newPos.y;
            wrapY = true;
        }

        transform.position = newPos;
    }
}
