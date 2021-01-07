using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingTimer : MonoBehaviour
{
    private float cutSceneTimer;

    // Start is called before the first frame update
    void Start()
    {
        cutSceneTimer = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        cutSceneTimer -= Time.deltaTime;

        if (cutSceneTimer <= 0)
        {
             SceneManager.LoadScene("Credits");
        }
    }
}
