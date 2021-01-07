using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hub2 : MonoBehaviour
{
    public SceneLoader loader = null;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            loader.LoadScene("Outside Hub 1");
        }

        if (Input.GetKeyDown("2"))
        {
            loader.LoadScene("Outside Hub 2");
        }

        if (Input.GetKeyDown("3"))
        {
            loader.LoadScene("Outside Hub 3");
        }
    }
}
