using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashlightPanel : MonoBehaviour
{
    public HUD hud;
    public Image lensSelectionIndicator;
    public Image bulbSelectionIndicator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (hud.flashlightController.scrollMode)
        {
            case FlashlightController.ScrollMode.BULBS:
                bulbSelectionIndicator.enabled = true;
                lensSelectionIndicator.enabled = false;
                break;
            case FlashlightController.ScrollMode.LENSES:
                bulbSelectionIndicator.enabled = false;
                lensSelectionIndicator.enabled = true;
                break;
        }
    }
}
