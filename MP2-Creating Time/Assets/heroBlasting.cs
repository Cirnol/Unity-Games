using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heroBlasting : MonoBehaviour
{
    public GameObject egg;

    private float blastingRate;
    private float cooldown;
    private bool firstEgg;

    // Start is called before the first frame update
    void Start()
    {
        blastingRate = .2f;
        cooldown = Time.time + blastingRate;
        firstEgg = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if(firstEgg)
            {
                Instantiate(egg, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
                firstEgg = false;
            }
            else
            {
                cooldown -= Time.deltaTime;
                if (cooldown <= 0)
                {
                    Instantiate(egg, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
                    cooldown = blastingRate;
                }
            }
        }
        else
        {
            cooldown -= Time.deltaTime;
            if (cooldown <= 0)
                firstEgg = true;
        }
    }
}
