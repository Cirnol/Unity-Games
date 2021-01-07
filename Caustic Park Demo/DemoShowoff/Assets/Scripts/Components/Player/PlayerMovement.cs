using System.Net.Http.Headers;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    #region Instance Variables

    [SerializeField] private float OGspeed;
    private float speed;

    private Rigidbody2D rb;

    private Vector3 mousePosition;
    private Vector3 aimDir;

    public armMovement arm = null;

    public Vector3 position;
    public bool hasShifted = false;

    public RandomSound footstepSounds;
    public float footstepTime;
    public AudioSource footstepSource;

    private bool locked = false;
    private Vector3 lockPosition;
    private float lastFootstepTime;
    #endregion

    private void Start()
    {
        speed = OGspeed;
        rb = GetComponent<Rigidbody2D>();
        position = rb.position;
        lockPosition = rb.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit something");
        if (collision.transform.name == "CameraLock")
        {
            CameraLocationSetter location = collision.gameObject.GetComponent<CameraLocationSetter>();
            lockPosition = new Vector3(location.xPos, location.yPos, transform.position.z);
            locked = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.name == "CameraLock")
        {
            locked = false;
            lockPosition = rb.position;
        }
    }

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            hasShifted = true;
            speed = OGspeed / 2;
        } else
        {
            speed = OGspeed;
        }
        UpdatePosition();
        UpdateCamera();
        UpdateAngle();
        arm.armUpdate();

    }

    #region Private Methods

    private void UpdatePosition()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 input = new Vector3(horizontal, vertical, 0);
        if (input.magnitude > 0.25)
        {
            lastFootstepTime += Time.fixedDeltaTime;
            if (lastFootstepTime > footstepTime)
            {
                lastFootstepTime = 0;
                footstepSource.PlayOneShot(footstepSounds.randomSound());
            }
        }
        input = input * Time.fixedDeltaTime * speed;
        input = Vector3.ClampMagnitude(input, speed * Time.deltaTime);
        
        input = new Vector3(transform.position.x + input.x, transform.position.y + input.y, transform.position.z);

        rb.MovePosition(input);
    }

    private void UpdateAngle()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        aimDir = mousePosition - gameObject.transform.position;
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        angle = (angle + 360) % 360;  // +360 for implementations where mod returns negative numbers


        if (angle >= 46 && angle <= 135) // North
        {
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                gameObject.GetComponent<Animator>().Play("Child_WalkNorthBackward");
            }
            else
            {
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    gameObject.GetComponent<Animator>().Play("Child_WalkNorthForward");
                }
                else
                {
                    if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                    {
                        gameObject.GetComponent<Animator>().Play("Child_WalkNorthLeft");
                    }
                    else
                    {
                        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                        {
                            gameObject.GetComponent<Animator>().Play("Child_WalkNorthRight");
                        }
                        else
                            gameObject.GetComponent<Animator>().Play("Child_Look_Up");
                    }
                }
            }
        }

        if (angle >= 316 || angle <= 45) // East
        {
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                gameObject.GetComponent<Animator>().Play("Child_WalkEastDown");
            }
            else
            {
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    gameObject.GetComponent<Animator>().Play("Child_WalkEastUp");
                }
                else
                {
                    if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                    {
                        gameObject.GetComponent<Animator>().Play("Child_WalkEastBackward");
                    }
                    else
                    {
                        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                        {
                            gameObject.GetComponent<Animator>().Play("Child_WalkEastForward");
                        }
                        else
                            gameObject.GetComponent<Animator>().Play("Child_Look_Right");
                    }
                }
            }
            
        }

        if (angle >= 226 && angle <= 315) // South
        {
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                gameObject.GetComponent<Animator>().Play("Child_WalkSouthForward");
            }
            else
            {
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    gameObject.GetComponent<Animator>().Play("Child_WalkSouthBackward");
                }
                else
                {
                    if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                    {
                        gameObject.GetComponent<Animator>().Play("Child_WalkSouthLeft");
                    }
                    else
                    {
                        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                        {
                            gameObject.GetComponent<Animator>().Play("Child_WalkSouthRight");
                        }
                        else
                            gameObject.GetComponent<Animator>().Play("Child_Look_Down");
                    }
                }
            }
        }

        if (angle >= 136 && angle <= 225) // West
        {
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                gameObject.GetComponent<Animator>().Play("Child_WalkWestDown");
            }
            else
            {
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    gameObject.GetComponent<Animator>().Play("Child_WalkWestUp");
                }
                else
                {
                    if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                    {
                        gameObject.GetComponent<Animator>().Play("Child_WalkWestForward");
                    }
                    else
                    {
                        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                        {
                            gameObject.GetComponent<Animator>().Play("Child_WalkWestBackward");
                        }
                        else
                            gameObject.GetComponent<Animator>().Play("Child_Look_Left");
                    }
                }
            }
        }
    }

    private void UpdateCamera()
    {
        if (!locked && Mathf.Abs(lockPosition.x - position.x) < 0.01)
        {
            position = rb.position;
            lockPosition = rb.position;
        }
        else if (!locked)
        {
            Debug.Log(lockPosition.x - position.x);
            lockPosition = rb.position;
            position = Vector3.Lerp(position, lockPosition, 0.1f);
        }
        else
        {
            position = Vector3.Lerp(position, lockPosition, 0.1f);
        }
    }

    #endregion

}
