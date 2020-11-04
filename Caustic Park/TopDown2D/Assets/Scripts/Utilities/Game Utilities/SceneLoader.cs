using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public bool load = false;
    public int sceneToLoad = 1;
    public FloatVariable variable;

    private void Awake()
    {
        variable.value = 100;
    }

    private void Update()
    {
        if(load)
        {
            load = false;
            LoadScene();
        }
    }

    public void LoadScene()
    {
        variable.value = 80;
        SceneManager.LoadScene(sceneToLoad);
    }
}
