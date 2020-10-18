using System.Collections;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using UnityEngine;
using UnityEngine.EventSystems;

public class selectingScript : MonoBehaviour
{
    public Renderer rend;
    private int shapesLayer;
    private int uiLayer;
    private float alphaMat;
    public static GameObject selectedObj;
    private GameObject objToDelete;
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

        // Extra Functions

        // Delete Object
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Right click!");

            if (EventSystem.current.IsPointerOverGameObject())
                return;

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1000.0f, shapesLayer))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    objToDelete = gameObject;

                    if (objToDelete.name == "Cube")
                        Destroy(gameObject);

                    if (objToDelete.name == "Sphere")
                        Destroy(gameObject);

                    if (objToDelete.name == "Cylinder")
                        Destroy(gameObject);
                }
            }
        }

    }
}
