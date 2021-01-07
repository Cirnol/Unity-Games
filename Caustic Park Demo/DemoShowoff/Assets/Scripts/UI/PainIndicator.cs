using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PainIndicator : MonoBehaviour
{
    public HUD hud;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Color color = GetComponent<Image>().color;
        color = hud.painIndicator;
        GetComponent<Image>().color = color;
    }
}
