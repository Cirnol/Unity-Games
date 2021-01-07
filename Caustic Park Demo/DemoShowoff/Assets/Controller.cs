using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public LayerMask InteractableMask;
    public TheWorld theWorld = null;
    public Camera mainCamera = null;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit2D RaycastHit2D = Physics2D.Raycast(new Vector2(mainCamera.ScreenToWorldPoint(Input.mousePosition).x, mainCamera.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero, 0, InteractableMask);
            if (RaycastHit2D)
            {
                Debug.Log("Clicked");
                theWorld.clicked(RaycastHit2D.collider.gameObject);
            }
        }

        
    }
}
