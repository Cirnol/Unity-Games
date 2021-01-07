using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject hud;
    public SceneLoader loader;

    private bool paused = false;

    private void Awake()
    {
        pauseMenu = GetComponentInChildren<Canvas>().gameObject;
        hud = FindObjectOfType<HUD>().gameObject;
        loader = FindObjectOfType<SceneLoader>();
        if(loader == null)
        {
            loader = gameObject.AddComponent<SceneLoader>();
        }
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Tab))
        {
            paused = !paused;
            if (paused)
                Pause();
            else
                Resume();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        if(hud)
            hud.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        if (hud)
            hud.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void MainMenu()
    {
        loader.LoadScene("Main Menu");
    }
}
