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
    private GameObject child;
    private float offSet;

    // Start is called before the first frame update
    void Start()
    {
        menu = GetComponent<Dropdown>();
        tempVal = menu.value;
        val = 0;
        offSet = 1f;
        spawn = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        val = menu.value;

        if(selectedObj != null)
        {
            spawn = selectedObj.transform.position;
        }
        else
        {
            spawn = new Vector3(offSet, offSet, offSet);
        }
           

        if (val == 1)
        {
            child = Instantiate(cube, new Vector3(spawn.x + offSet, spawn.y + offSet, spawn.z + offSet), Quaternion.identity);
            child.name = "Cube";

            // Assigning color and generation
            if (selectedObj != null)
            {
                if (selectedObj.tag == "Grandparent")
                {
                    child.transform.parent = selectedObj.transform;
                    child.tag = "FirstGen";
                    child.GetComponent<MeshRenderer>().material.color = new Color(.1f, 1f, .1f, 1f); // Green
                }
                else
                {
                    if (selectedObj.tag == "Parent")
                    {
                        child.transform.parent = selectedObj.transform;
                        child.tag = "SecondGen";
                        child.GetComponent<MeshRenderer>().material.color = new Color(1f, 0f, .25f, 1f); // Red
                    }
                    else
                    {
                        child.transform.parent = selectedObj.transform;
                        child.tag = "ThirdGen";
                        child.GetComponent<MeshRenderer>().material.color = new Color(1f, 1f, 1f, 1f); // White
                    }
                }
            }
            else
            {
                child.transform.parent = null;
                child.tag = "Null";
                child.GetComponent<MeshRenderer>().material.color = new Color(.1f, 0f, .1f, 1f); // Black
            }

        }
        if (val == 2)
        {
            child = Instantiate(sphere, new Vector3(spawn.x + offSet, spawn.y + offSet, spawn.z + offSet), Quaternion.identity);
            child.name = "Sphere";

            // Assigning color and generation
            if (selectedObj != null)
            {
                if (selectedObj.tag == "Grandparent")
                {
                    child.transform.parent = selectedObj.transform;
                    child.tag = "FirstGen";
                    child.GetComponent<MeshRenderer>().material.color = new Color(.1f, 1f, .1f, 1f); // Green
                }
                else
                {
                    if (selectedObj.tag == "Parent")
                    {
                        child.transform.parent = selectedObj.transform;
                        child.tag = "SecondGen";
                        child.GetComponent<MeshRenderer>().material.color = new Color(1f, 0f, .25f, 1f); // Red
                    }
                    else
                    {
                        child.transform.parent = selectedObj.transform;
                        child.tag = "ThirdGen";
                        child.GetComponent<MeshRenderer>().material.color = new Color(1f, 1f, 1f, 1f); // White
                    }
                }
            }
            else
            {
                child.transform.parent = null;
                child.tag = "Null";
                child.GetComponent<MeshRenderer>().material.color = new Color(.1f, 0f, .1f, 1f); // Black
            }

        }
        if (val == 3)
        {
            child = Instantiate(cyl, new Vector3(spawn.x + offSet, spawn.y + offSet, spawn.z + offSet), Quaternion.identity);
            child.name = "Cylinder";

            // Assigning color and generation
            if (selectedObj != null)
            {
                if (selectedObj.tag == "Grandparent")
                {
                    child.transform.parent = selectedObj.transform;
                    child.tag = "FirstGen";
                    child.GetComponent<MeshRenderer>().material.color = new Color(.1f, 1f, .1f, 1f); // Green
                }
                else
                {
                    if (selectedObj.tag == "Parent")
                    {
                        child.transform.parent = selectedObj.transform;
                        child.tag = "SecondGen";
                        child.GetComponent<MeshRenderer>().material.color = new Color(1f, 0f, .25f, 1f); // Red
                    }
                    else
                    {
                        child.transform.parent = selectedObj.transform;
                        child.tag = "ThirdGen";
                        child.GetComponent<MeshRenderer>().material.color = new Color(1f, 1f, 1f, 1f); // White
                    }
                }
            }
            else
            {
                child.transform.parent = null;
                child.tag = "Null";
                child.GetComponent<MeshRenderer>().material.color = new Color(.1f, 0f, .1f, 1f); // Black
            }
        }

        menu.value = tempVal;
        val = menu.value;
    }
}
