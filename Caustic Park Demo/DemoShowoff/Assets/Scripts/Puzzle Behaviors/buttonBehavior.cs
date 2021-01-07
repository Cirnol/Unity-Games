using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class buttonBehavior : MonoBehaviour
{
    public TheWorld theWorld = null;
    public bool isSeen = false;
    private float timer = 0.0f;
    private float maxTime = 2.0f;
    private bool alreadyActive = false;

    private float blinkTimer = 0.0f;
    private float maxBlink = 0.5f;

    private bool resetting = false;
    //public buttonDisplay display;

    public List<Sprite> offSprite;
    public List<Sprite> sensingSprite;
    public List<Sprite> onSprite;
    public List<Sprite> waitingSprite;
    private int buttonType = 0;

    public GameObject buttonRadius = null;
    [SerializeField] bool blacklightButton;

    [SerializeField] bool SequenceButton;
    [SerializeField] int buttonNum;

    [SerializeField] bool teamButton;
    public buttonBehavior myFriend = null;
    [SerializeField] bool positive;
    private void Start()
    {
        //display.setSprite(1);
    }
    private void Update()
    {
        if(teamButton)
        {
            if(positive)
            {
                buttonType = 1;
            } else
            {
                buttonType = 2;
            }
            
        }
        if(SequenceButton)
        {
            buttonType = 3;
        }
        if(blacklightButton)
        {
            if(theWorld.getBulb().name == "Blacklight" || alreadyActive)
            {
                GetComponent<SpriteRenderer>().enabled = true;
                GetComponent<CircleCollider2D>().enabled = true;
            } else
            {
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<CircleCollider2D>().enabled = false;
            }
        }
        if(resetting)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = offSprite[buttonType];
            timer += Time.deltaTime;
            if(timer > 1.0f)
            {
                timer -= 1.0f;
                resetting = false;
            }
        }
        else if (!alreadyActive)
        {
            if (isSeen)
            {
                if (!teamButton || myFriend.AmISeen())
                {
                    if(theWorld.getBulb().power == Bulb.Power.NONE) {
                        timer += 2* Time.deltaTime;
                    }
                    timer += Time.deltaTime;
                    
                    Vector3 temp = buttonRadius.transform.localScale;
                    if (temp.x < 2)
                    {
                        if (theWorld.getBulb().power == Bulb.Power.NONE)
                        {
                            temp.x += 2* Time.deltaTime;
                            temp.z += 2* Time.deltaTime;
                        }
                        temp.x += Time.deltaTime;
                        temp.z += Time.deltaTime;
                    }
                    else
                    {
                        temp.x = 2;
                        temp.z = 2;
                    }
                    buttonRadius.transform.localScale = temp;

                    gameObject.GetComponent<SpriteRenderer>().sprite = sensingSprite[buttonType];
                    //display.setSprite(2);
                    if (timer > maxTime)
                    {
                        Debug.Log("im active");
                        gameObject.GetComponent<SpriteRenderer>().sprite = onSprite[buttonType];
                        //display.setSprite(3);
                        alreadyActive = true;
                        if(SequenceButton)
                        {
                            theWorld.checkButton(buttonNum);
                        } else
                        {
                            theWorld.addActiveButton();
                        }
                        
                    }
                } else
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = waitingSprite[buttonType];
                }
            }
            else
            {
                //display.setSprite(1);
                gameObject.GetComponent<SpriteRenderer>().sprite = offSprite[buttonType];
                Vector3 temp = buttonRadius.transform.localScale;
                if (temp.x > 0.1f)
                {
                    temp.x -= 1 * Time.deltaTime;
                    temp.z -= 1 * Time.deltaTime;
                } else
                {
                    blinkTimer += Time.deltaTime;
                    if(blinkTimer > maxBlink)
                    {
                        blinkTimer -= maxBlink;
                        if (temp.x <= 0)
                        {
                            temp.x = 0.1f;
                            temp.z = 0.1f;
                        }
                        else if (temp.x <= 0.1f)
                        {
                            temp.x = 0;
                            temp.z = 0;
                        }
                    }
                }
                buttonRadius.transform.localScale = temp;
            }
        }
        else
        {
            Vector3 temp = buttonRadius.transform.localScale;
            if (temp.x < 2)
            {
                temp.x += 1 * Time.deltaTime;
                temp.z += 1 * Time.deltaTime;
            }
            else
            {
                temp.x = 2;
                temp.z = 2;
            }
            buttonRadius.transform.localScale = temp;
        }


    }
    public void Seen(bool _isSeen)
    {
        isSeen = _isSeen;
    }

    public bool AmISeen()
    {
        return isSeen;
    }

    public void undo()
    {
        timer = 0.0f;
        resetting = true;
        alreadyActive = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = offSprite[buttonType];

    }

}
