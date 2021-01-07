using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsMenu : MonoBehaviour
{
    public List<GameObject> otherMenus = null;
    public GameObject pauseMenu;
    public PlayerMovement movement;
    public HUD hud;
    public FlashlightController controller = null;
    [SerializeField] bool scrollCheck;
    [SerializeField] bool bulbCheck;
    [SerializeField] bool flashlightOffCheck;
    [SerializeField] bool shiftCheck;

    private bool paused = false;

    private void Awake()
    {
        otherMenus.Add(FindObjectOfType<PauseMenu>().gameObject);
        PickupMenu[] pickupMenus = FindObjectsOfType<PickupMenu>();
        foreach (PickupMenu menu in pickupMenus)
        {
            if (menu != this)
            {
                otherMenus.Add(menu.gameObject);
            }
        }

        pauseMenu = GetComponentInChildren<Canvas>().gameObject;
        controller = FindObjectOfType<FlashlightController>();
        movement = FindObjectOfType<PlayerMovement>();
        pauseMenu.SetActive(false);
    }



    public void Pause()
    {
        Debug.Log("Paused");
        foreach (GameObject menu in otherMenus)
        {
            menu.SetActive(false);
        }
        pauseMenu.SetActive(true);
        controller.hasScrolled = false;
        controller.hasSwitched = false;
        controller.hasTurnedOff = false;
        movement.hasShifted = false;
        paused = true;
    }
    private void Update()
    {
        if (controller.battery != controller.maxBattery && paused == false)
        {
            Pause();
        }

        if (paused)
        {
            if(scrollCheck && controller.hasScrolled)
            {
                Resume();
            }
            else if(bulbCheck && controller.hasSwitched)
            {
                Resume();
            }
            else if (flashlightOffCheck && controller.hasTurnedOff)
            {
                Resume();
            }
            else if (shiftCheck && movement.hasShifted)
            {
                Resume();
            }
        }


    }
    public void Resume()
    {
        foreach (GameObject menu in otherMenus)
        {
            menu.SetActive(true);
        }
        Debug.Log("resumed");
        pauseMenu.SetActive(false);
        Debug.Log("aftertime");
    }
}


