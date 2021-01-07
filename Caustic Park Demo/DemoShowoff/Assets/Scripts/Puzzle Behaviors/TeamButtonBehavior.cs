using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamButtonBehavior : MonoBehaviour
{
    public TheWorld theWorld = null;
    private bool isSeen = false;
    private float timer = 0.0f;
    private float maxTime = 2.0f;
    private bool alreadyActive = false;
    public TeamButtonBehavior myFriend = null;
    //public buttonDisplay display;

    public Sprite offSprite;
    public Sprite sensingSprite;
    public Sprite onSprite;
    public Sprite waitingSprite;

    private void Update()
    {
        if (!alreadyActive)
        {
            if (isSeen)
            {
                if (myFriend.AmISeen())
                {
                    timer += Time.deltaTime;
                    gameObject.GetComponent<SpriteRenderer>().sprite = sensingSprite;
                    //display.setSprite(2);
                    if (timer > maxTime)
                    {
                        Debug.Log("im active");
                        gameObject.GetComponent<SpriteRenderer>().sprite = onSprite;
                        //display.setSprite(3);
                        alreadyActive = true;
                        theWorld.addActiveButton();
                    }
                } else
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = waitingSprite;
                }
            }
            else
            {
                //display.setSprite(1);
                gameObject.GetComponent<SpriteRenderer>().sprite = offSprite;
            }
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
}
