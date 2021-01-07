using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeSpriteRotation : MonoBehaviour
{
    public Sprite up = null;
    public Sprite left = null;
    public Sprite down = null;
    public Sprite right = null;

    public GameObject hero;

    void Update()
    {
        float d = (hero.transform.position - transform.position).magnitude;

        Vector3 parentRote = gameObject.GetComponentInParent<Transform>().localRotation.eulerAngles;
        //Debug.Log(parentRote.z);
        transform.rotation = Quaternion.identity;
        if((parentRote.z >= 315 && parentRote.z < 360) || (parentRote.z >= 0 && parentRote.z < 45)) // Up
        {
            if (d < 2.5)
            {
                gameObject.GetComponent<Animator>().Play("GruntAttackUp");
            }
            else
            {
                gameObject.GetComponent<Animator>().Play("GruntWalkUp");
            }

            
        } else if(parentRote.z < 135 && parentRote.z >= 45) // Right
        {
            if (d < 2.5)
            {
                gameObject.GetComponent<Animator>().Play("GruntAttackRight");
            }
            else
            {
                gameObject.GetComponent<Animator>().Play("GruntWalkRight");
            }

        } else if(parentRote.z < 220 && parentRote.z >= 135) // Down
        {
            if (d < 2.5)
            {
                gameObject.GetComponent<Animator>().Play("GruntAttackDown");
            }
            else
            {
                gameObject.GetComponent<Animator>().Play("GruntWalkDown");
            }

            
        } else if(parentRote.z >= 220 && parentRote.z < 315) // Left
        {
            if (d < 2.5)
            {
                gameObject.GetComponent<Animator>().Play("GruntAttackLeft");
            }
            else
            {
                gameObject.GetComponent<Animator>().Play("GruntWalkLeft");
            }
        }
    }
}
