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
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        Vector3 newPos = transform.position;
        if(viewPos.x < -.05f || viewPos.x > 1.05f)
        {
            newPos.x *= -1;
        }
        if (viewPos.y < -.05f || viewPos.y > 1.05f)
        {
            newPos.y *= -1;
        }
        transform.position = newPos;
    }
}
