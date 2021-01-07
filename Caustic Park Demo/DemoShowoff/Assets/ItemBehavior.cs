using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{

    public TheWorld theWorld;

    public Sprite RightDrink = null;
    public Sprite WrongDrink = null;

    [SerializeField] bool drinkItem;
    [SerializeField] bool floorItem;
    [SerializeField] bool helpItem;

    [SerializeField] bool badDrink;

    public GameObject myHeat = null;
    public GameObject fakeFloor = null;

    public bool isSeen = false;

    public PickupMenu menu = null;

    // Update is called once per frame
    void Update()
    {
        if(floorItem)
        {
            fakeFloor.GetComponent<Renderer>().enabled = !isSeen;
            myHeat.GetComponent<Renderer>().enabled = isSeen;
        } else if(drinkItem)
        {
            myHeat.SetActive(isSeen);
        }
        
    }

    public void Seen(bool _isSeen)
    {
        isSeen = _isSeen;
    }

    public void clicked()
    {
        if(drinkItem)
        {
            if (badDrink)
            {
                theWorld.dealDamage(34);
            }
            else
            {
                theWorld.drunk();
            }
            gameObject.SetActive(false);
        } else if(helpItem)
        {
            menu.Pause();
            gameObject.SetActive(false);
        }

    }

    public void setDrink(bool _badDrink)
    {
        badDrink = _badDrink;
        if (drinkItem)
        {
            if (badDrink)
            {
                myHeat.GetComponent<SpriteRenderer>().sprite = WrongDrink;
            }
            else
            {
                myHeat.GetComponent<SpriteRenderer>().sprite = RightDrink;
            }
        }
    } 


}
