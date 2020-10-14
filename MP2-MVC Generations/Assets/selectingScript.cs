using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class selectingScript : MonoBehaviour
{
    public Renderer rend;
    private int shapesLayer;
    private int uiLayer;
    private float alphaMat;
    public static GameObject selectedObj;
    //public static bool dontRaycast;
    public GameObject dropdownMenu;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        uiLayer = (1 << 5);
        shapesLayer = (1 << 8);
        alphaMat = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1000.0f, shapesLayer))
            {
                if(hit.collider.gameObject == gameObject)
                {
                    alphaMat = 0.64f;
                    hit.collider.GetComponent<MeshRenderer>().material.color = new Color(1f, 1f, .1f, alphaMat);
                    selectedObj = gameObject;
                }
                else
                {
                    alphaMat = 1;

                    if (gameObject.tag == "Grandparent")
                        this.GetComponent<MeshRenderer>().material.color = new Color(.1f, 1f, 1f, alphaMat); // Blue
                    if (gameObject.tag == "FirstGen" || gameObject.tag == "Parent")
                        this.GetComponent<MeshRenderer>().material.color = new Color(.1f, 1f, .1f, alphaMat); // Green
                    if (gameObject.tag == "SecondGen" || gameObject.tag == "Child")
                        this.GetComponent<MeshRenderer>().material.color = new Color(1f, 0f, .25f, alphaMat); // Red
                    if (gameObject.tag == "ThirdGen")
                        this.GetComponent<MeshRenderer>().material.color = new Color(1f, 1f, 1f, alphaMat); // White
                    if (gameObject.tag == "Null")
                        this.GetComponent<MeshRenderer>().material.color = new Color(.1f, 0f, .1f, alphaMat); // Black
                }
            }
            else
            {
                alphaMat = 1;

                if (gameObject.tag == "Grandparent")
                    this.GetComponent<MeshRenderer>().material.color = new Color(.1f, 1f, 1f, alphaMat); // Blue
                if (gameObject.tag == "FirstGen" || gameObject.tag == "Parent")
                    this.GetComponent<MeshRenderer>().material.color = new Color(.1f, 1f, .1f, alphaMat); // Green
                if (gameObject.tag == "SecondGen" || gameObject.tag == "Child")
                    this.GetComponent<MeshRenderer>().material.color = new Color(1f, 0f, .25f, alphaMat); // Red
                if (gameObject.tag == "ThirdGen")
                    this.GetComponent<MeshRenderer>().material.color = new Color(1f, 1f, 1f, alphaMat); // White
                if (gameObject.tag == "Null")
                    this.GetComponent<MeshRenderer>().material.color = new Color(.1f, 0f, .1f, alphaMat); // Black

                selectedObj = null;
            }
        }
    }

    //void OnMouseEnter()
    //{

    //    if (gameObject.tag == "Cube")
    //        rend.GetComponent<MeshRenderer>().material.color = new Color(.1f, 1f, 1f, .64f);
    //    if (gameObject.tag == "Sphere")
    //        rend.GetComponent<MeshRenderer>().material.color = new Color(.1f, 1f, .1f, .64f);
    //    if (gameObject.tag == "Cylinder")
    //        rend.GetComponent<MeshRenderer>().material.color = new Color(1f, 0f, .25f, .64f);
    //    if (gameObject.tag == "Null")
    //        rend.GetComponent<MeshRenderer>().material.color = new Color(.1f, 0f, .1f, .64f);
        
    //}

    //void OnMouseExit()
    //{
    //    alphaMat = 1;

    //    if (gameObject.tag == "Cube")
    //        this.GetComponent<MeshRenderer>().material.color = new Color(.1f, 1f, 1f, alphaMat);
    //    if (gameObject.tag == "Sphere")
    //        this.GetComponent<MeshRenderer>().material.color = new Color(.1f, 1f, .1f, alphaMat);
    //    if (gameObject.tag == "Cylinder")
    //        this.GetComponent<MeshRenderer>().material.color = new Color(1f, 0f, .25f, alphaMat);
    //    if (gameObject.tag == "Null")
    //        this.GetComponent<MeshRenderer>().material.color = new Color(.1f, 0f, .1f, alphaMat);
    //}
}
