using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonDisplay : MonoBehaviour
{
    // Update is called once per frame

    public Sprite offSprite;
    public Sprite sensingSprite;
    public Sprite onSprite;

    public void setSprite(int spriteNum)
    {
        switch (spriteNum) {
            case 1:
                gameObject.GetComponent<SpriteRenderer>().sprite = offSprite;
                break;
            case 2:
                gameObject.GetComponent<SpriteRenderer>().sprite = sensingSprite;
                break;
            case 3:
                gameObject.GetComponent<SpriteRenderer>().sprite = onSprite;
                break;
        }

    }
}
