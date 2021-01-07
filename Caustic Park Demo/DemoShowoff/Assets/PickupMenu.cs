using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupMenu : MonoBehaviour
{
    public List<GameObject> otherMenus = null;
    public GameObject pauseMenu;
    public GameObject hud;

    private bool paused = false;

    private void Awake()
    {
        otherMenus.Add(FindObjectOfType<PauseMenu>().gameObject);
        PickupMenu[] pickupMenus = FindObjectsOfType<PickupMenu>();
        foreach (PickupMenu menu in pickupMenus)
        {
            if(menu != this)
            {
                otherMenus.Add(menu.gameObject);
            }
        }
        
        pauseMenu = GetComponentInChildren<Canvas>().gameObject;
        hud = FindObjectOfType<HUD>().gameObject;
        pauseMenu.SetActive(false);
    }



    public void Pause()
    {
        Debug.Log("Paused");
        Time.timeScale = 0;
        foreach (GameObject menu in otherMenus)
        {
            menu.SetActive(false);
        }
        if (hud)
            hud.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        foreach (GameObject menu in otherMenus)
        {
            menu.SetActive(true);
        }
        Debug.Log("resumed");
        Time.timeScale = 1;
        hud.SetActive(true);
        Debug.Log("aftertime");
    }
}

