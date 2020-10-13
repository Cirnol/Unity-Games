using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectingScript : MonoBehaviour
{
    private int shapesLayer;
    private float alphaMat;

    // Start is called before the first frame update
    void Start()
    {
        shapesLayer = (1 << 8);
        alphaMat = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1000.0f, shapesLayer) && hit.collider.gameObject == gameObject)
            {
                alphaMat = 0.64f;
                hit.collider.GetComponent<MeshRenderer>().material.color = new Color(1f, 1f, .1f, alphaMat);
            }
            else
            {
                alphaMat = 1;

                if (gameObject.tag == "Cube")
                    this.GetComponent<MeshRenderer>().material.color = new Color(.1f, 1f, 1f, alphaMat);
                if (gameObject.tag == "Sphere")
                    this.GetComponent<MeshRenderer>().material.color = new Color(.1f, 1f, .1f, alphaMat);
                if (gameObject.tag == "Cylinder")
                    this.GetComponent<MeshRenderer>().material.color = new Color(1f, 0f, .25f, alphaMat);
                if (gameObject.tag == "Null")
                    this.GetComponent<MeshRenderer>().material.color = new Color(.1f, 0f, .1f, alphaMat);
            }
        }
    }
}
