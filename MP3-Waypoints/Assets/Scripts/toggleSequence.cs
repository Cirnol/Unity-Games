using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleSequence : MonoBehaviour
{
    public static bool sequential;

    // Start is called before the first frame update
    void Start()
    {
        sequential = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
            sequential = !sequential;
    }
}
