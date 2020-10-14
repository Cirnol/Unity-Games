using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static selectingScript;

public class menuFunctions : MonoBehaviour
{
    Dropdown menu;
    int val;
    int tempVal;
    Vector3 spawn;
    public GameObject cube;
    public GameObject sphere;
    public GameObject cyl;
    private float offSet;

    // Start is called before the first frame update
    void Start()
    {
        menu = GetComponent<Dropdown>();
        tempVal = menu.value;
        val = 0;
        offSet = 0.1f;
        spawn = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        val = menu.value;

        if(selectedObj != null)
        {
            spawn = selectedObj.transform.position;
            Debug.Log("Current selected object: " + selectedObj.tag);
        }
        else
        {
            spawn = new Vector3(1 - offSet, 1 - offSet, 1 - offSet);
            Debug.Log("Current selected object: NULL");
        }
           

        if (val == 1)
        {
            Instantiate(cube, new Vector3(spawn.x + offSet, spawn.y + offSet, spawn.z + offSet), Quaternion.identity);
        }
        if (val == 2)
        {
            Instantiate(sphere, new Vector3(spawn.x + offSet, spawn.y + offSet, spawn.z + offSet), Quaternion.identity);
        }
        if (val == 3)
        {
            Instantiate(cyl, new Vector3(spawn.x + offSet, spawn.y + offSet, spawn.z + offSet), Quaternion.identity);
        }

        menu.value = tempVal;
        val = menu.value;

    }
}
