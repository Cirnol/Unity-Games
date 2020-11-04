using System.Net.Http.Headers;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    #region Instance Variables

    [SerializeField] private float speed = 10;

    private Rigidbody2D rb;

    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        UpdatePosition();
    }

    #region Private Methods

    private void UpdatePosition()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 input = new Vector3(horizontal, vertical, 0);
        input = input * Time.deltaTime * speed;
        input = Vector3.ClampMagnitude(input, speed * Time.deltaTime);

        input = new Vector3(transform.position.x + input.x, transform.position.y + input.y, transform.position.z);

        rb.MovePosition(input);
    }

    #endregion

}
