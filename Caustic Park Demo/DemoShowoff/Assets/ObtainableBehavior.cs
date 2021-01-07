using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtainableBehavior : MonoBehaviour
{
    public FlashlightController flashlightController = null;
    [SerializeField] bool isLens;
    [SerializeField] bool isBulb;
    public Lens meLens = null;
    public Bulb meBulb = null;
    [SerializeField] bool menuPickup;
    public PickupMenu menu = null;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.name == "Child")
        {
            if(isLens)
            {
                flashlightController.AddLense(meLens);
            } 
            else if(isBulb)
            {
                flashlightController.AddBulb(meBulb);
            }
            menu.Pause();
            gameObject.SetActive(false);
        }
    }
}
