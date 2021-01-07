using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudioTrigger : MonoBehaviour
{
    public List<State> triggerStates;
    public float cooldown;
    private bool triggered = false;
    private float t0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerStates.Contains(GetComponent<EnemyStateController>().CurrentState))
        {
            t0 = Time.time;
            bool enemySeen = FindObjectOfType<Hero>().fov.IsEnemySeen(transform);
            if (!triggered && enemySeen)
            {
                GetComponent<AudioSource>().Play();
                triggered = true;
            }
        } else
        {
            if (Time.time - t0 > cooldown)
            {
                triggered = false;
                GetComponent<AudioSource>().Stop();
            }
        }
    }
}
