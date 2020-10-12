using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instanceCount : MonoBehaviour
{
    public static int countA;
    public static int countB;
    public static int countC;
    public static int countD;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Instances of A: " + countA);
        Debug.Log("Instances of B: " + countB);
        Debug.Log("Instances of C: " + countC);
        Debug.Log("Instances of D: " + countD);
    }
}
