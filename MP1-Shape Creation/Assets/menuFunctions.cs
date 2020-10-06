using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuFunctions : MonoBehaviour
{
    Dropdown menu;
    int val;
    int tempVal;
    Vector3 spawn;
    public GameObject creator;
    public GameObject cube;
    public GameObject sphere;
    public GameObject cyl;

    // Start is called before the first frame update
    void Start()
    {
        menu = GetComponent<Dropdown>();
        tempVal = menu.value;
        val = 0;
    }

    // Update is called once per frame
    void Update()
    {
        val = menu.value;
        spawn = creator.transform.position;

        if (val == 1)
        {
            Instantiate(cube, new Vector3(spawn.x, 0.5f, spawn.z), Quaternion.identity);
        }
        if (val == 2)
        {
            Instantiate(sphere, new Vector3(spawn.x, 0.5f, spawn.z), Quaternion.identity);
        }
        if (val == 3)
        {
            Instantiate(cyl, new Vector3(spawn.x, 2, spawn.z), Quaternion.identity);
        }

        menu.value = tempVal;
        val = menu.value;

    }
}
