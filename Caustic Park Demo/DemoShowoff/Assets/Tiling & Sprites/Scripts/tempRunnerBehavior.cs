using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempRunnerBehavior : MonoBehaviour
{
    public GameObject hero;

    private float stareTimer;
    private float chaseTimer;

    private bool awake;

    public ScriptableObject states;

    // Start is called before the first frame update
    void Start()
    {
        stareTimer = 5;
        chaseTimer = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 parentRote = gameObject.GetComponentInParent<Transform>().localRotation.eulerAngles;
        transform.rotation = Quaternion.identity;


        float d = (hero.transform.position - transform.position).magnitude;

        if (d < 7)
        {
            awake = true;
        }


        if(awake)
        {
            if (stareTimer > 0)
            {
                stareTimer -= Time.deltaTime;
            }

            if(stareTimer <= 0)
            {
                gameObject.GetComponent<Animator>().Play("Running");

                if (chaseTimer > 0)
                {
                    if(d >= 7)
                    {
                        chaseTimer -= Time.deltaTime;
                    }
                }
            }
            else
            {
                gameObject.GetComponent<Animator>().Play("Awaken");
            }

            if(chaseTimer <= 0)
            {
                gameObject.GetComponent<Animator>().Play("Hide");
                awake = false;
                stareTimer = 5;
                chaseTimer = 3;
            }
        }


    }
}
