using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitDoorBehavior : MonoBehaviour
{
    [SerializeField] bool popup;
    private SceneLoader loader;
    [SerializeField] string sceneToLoad;
    public PickupMenu menu = null;
    private Image fadeIn;
    private bool fadingOut = false;
    private float fadeTimer = 0.0f;
    private float maxTime = 1.0f;

    private void Start()
    {
        loader = FindObjectOfType<SceneLoader>();
        fadeIn = GameObject.Find("Fade In").GetComponent<Image>();
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(popup)
        {
            menu.Pause();
        }
        else
        {
            fadingOut = true;
        }

    }
    private void Update()
    {
        if(fadingOut)
        {
            if (fadeTimer < maxTime)
            {
                fadeTimer += Time.deltaTime;
                Color color = fadeIn.color;
                color.a = 0 + (fadeTimer * 2);
                fadeIn.color = color;
            }
            else
            {
                loader.LoadScene(sceneToLoad);
            }
        }
    }

    public void loadScene()
    {
        loader.LoadScene(sceneToLoad);
    }
}
