using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SceneNode;

public class SmallCamera : MonoBehaviour
{
    GameObject nodeWithMatrix;
    SceneNode nodeScript;

    // Start is called before the first frame update
    void Start()
    {
        nodeWithMatrix = GameObject.Find("Camera");
        nodeScript = nodeWithMatrix.GetComponent<SceneNode>();
    }

    // Update is called once per frame
    void Update()
    {
        // get matrix from the Transform
        Matrix4x4 nodeMatrix = nodeScript.mCombinedParentXform;
        // get position from the last column
        var position = new Vector3(nodeMatrix[0, 3], nodeMatrix[1, 3], nodeMatrix[2, 3]);
        gameObject.transform.position = new Vector3(position.x, position.y, position.z);
        gameObject.transform.forward = nodeWithMatrix.transform.up;
    }

    //public void loadCombinedMatrix(ref Matrix4x4 nodeMatrix)
    //{
    //    var position = nodeMatrix.GetColumn(3);
    //    gameObject.transform.position = position;
    //    Debug.Log("Transform position from matrix is: " + position);
    //}
}
