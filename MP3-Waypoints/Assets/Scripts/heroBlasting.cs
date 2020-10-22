using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heroBlasting : MonoBehaviour
{
    public GameObject egg;

    public static float blastingRate;
    public static float cooldown;

    // Start is called before the first frame update
    void Start()
    {
        blastingRate = 0.2f;
        cooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
        {
            if (cooldown <= 0)
            {
                Instantiate(egg, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
                cooldown = blastingRate;
            }
        }
    }
}
