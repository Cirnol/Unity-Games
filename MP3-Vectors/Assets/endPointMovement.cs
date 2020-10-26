using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class endPointMovement : MonoBehaviour
{
    private Vector3 target;
    private int wallA;
    private int wallB;
    public GameObject epA;
    public GameObject epB;


    // Start is called before the first frame update
    void Start()
    {
        wallA = (1 << 8);
        wallB = (1 << 9);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Checks for object to be deleted before allowing movement

            if (Physics.Raycast(ray, out hit, 1000.0f, wallA))
            {
                target = hit.point; // Obtain the coordinates
                epA.transform.position = target; // Object moves to those coordinates
            }

            if (Physics.Raycast(ray, out hit, 1000.0f, wallB))
            {
                target = hit.point; // Obtain the coordinates
                epB.transform.position = target; // Object moves to those coordinates
            }
        }
    }
}
