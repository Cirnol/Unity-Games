using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class creationTarget : MonoBehaviour
{
    private Vector3 target;
    private int quadLayer;
    private int shapesLayer;

    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
        quadLayer = (1 << 8);
        shapesLayer = (1 << 9);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1000.0f, shapesLayer))
            {
                Destroy(hit.collider.gameObject);
            }
            else
            {
                if (Physics.Raycast(ray, out hit, 1000.0f, quadLayer))
                {
                    target = hit.point;
                    target.y = transform.position.y;
                    transform.position = target;
                }
            }
        }

        //Raycast code obtained from: https://answers.unity.com/questions/773911/move-object-to-mouse-click-position.html 
    }
}
