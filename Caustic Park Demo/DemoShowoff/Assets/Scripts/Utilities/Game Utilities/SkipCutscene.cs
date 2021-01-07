using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkipCutscene : MonoBehaviour
{
    private float timer;
    private float skipTimer;
    private float cutSceneTimer;
    public GameObject skip;

    // Start is called before the first frame update
    void Start()
    {
        timer = 1;
        skipTimer = 1.5f;
        cutSceneTimer = 18f;
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if (Input.anyKey)
        {
            skip.active = true;
            skipTimer = 1.5f;
        }

        skipTimer -= Time.deltaTime;
        if (skipTimer <= 0)
            skip.active = false;

        if (Input.GetKey(KeyCode.Space))
        {
            timer -= Time.deltaTime;
            Debug.Log(timer);
        }

        cutSceneTimer -= Time.deltaTime;

        if (timer <= 0 || cutSceneTimer <= 0)
        {
            Application.LoadLevel("Outside Hub 1");
        }
    }
}
