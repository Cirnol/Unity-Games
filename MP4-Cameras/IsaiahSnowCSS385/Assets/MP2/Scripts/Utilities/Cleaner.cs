using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Cleaner : MonoBehaviour
{
    private Renderer render;

    void Start()
    {
        render = GetComponent<Renderer>();
    }

    void Update()
    {
        if(!render.isVisible)
        {
            Destroy(gameObject);
        }
    }
}
