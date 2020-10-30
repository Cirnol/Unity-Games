using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

 class Game : MonoBehaviour
{
    public Globals global;

    private void Start()
    {
        global.waypointCam = FindObjectOfType<WaypointCam>();
        global.waypointCam.gameObject.SetActive(false);
        global.enemyCam = FindObjectOfType<EnemyCam>();
        global.enemyCam.gameObject.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(0);
        }
    }
}
