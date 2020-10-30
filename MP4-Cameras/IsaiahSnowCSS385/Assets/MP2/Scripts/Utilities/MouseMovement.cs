using UnityEngine;

public class MouseMovement : MonoBehaviour
{

    void Update()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        Vector3 newPos = Vector3.Lerp(transform.position, mousePosition, .05f);

        transform.position = newPos;
    }
}
