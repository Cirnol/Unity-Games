using UnityEngine;

public class MouseRotation : MonoBehaviour
{
    private Camera cam;
    float angle;
    Vector2 mousePos;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), .8f);
    }
}
