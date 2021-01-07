using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public bool load = false;
    public int sceneToLoad = 1;
    public float fadeTimer = 0.0f;
    private float maxTime = 1f;

    private GameObject fadeIn;
    private Image rend;

    private bool fadingIn = true;
    private bool fadingOut = false;
    private void Awake()
    {
        fadeIn = GameObject.Find("Fade In");
        rend = fadeIn.GetComponent<Image>();
    }


    private void Update()
    {
        if (fadingIn)
        {
            if (fadeTimer < maxTime)
            {
                fadeTimer += Time.deltaTime;
                Color color = rend.color;
                color.a = 1 - (fadeTimer * 2);
                rend.color = color;
            }
            else
            {
                fadeTimer -= maxTime;
                Color finalCol = rend.color;
                finalCol.a = 0;
                rend.color = finalCol;
                fadingIn = false;
            }
        }

        
    }
    public void LoadScene(int scene)
    {
        fadingOut = true;
        SceneManager.LoadScene(scene);
        Time.timeScale = 1;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
