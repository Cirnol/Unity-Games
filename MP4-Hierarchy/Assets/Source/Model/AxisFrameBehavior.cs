using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SceneNode;
using static XfromControl;

public class AxisFrameBehavior : MonoBehaviour
{
    GameObject nodeWithMatrix;
    SceneNode nodeScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // get matrix from the Transform
        Matrix4x4 nodeMatrix = nodeScript.mCombinedParentXform;
        // get position from the last column
        var position = new Vector3(nodeMatrix[0, 3], nodeMatrix[1, 3], nodeMatrix[2, 3]);
        gameObject.transform.position = new Vector3(position.x, position.y, position.z);
        transform.rotation = nodeWithMatrix.transform.rotation;

        //gameObject.transform.up = nodeWithMatrix.transform.up;
        //gameObject.transform.forward = nodeWithMatrix.transform.forward;
        //gameObject.transform.right = nodeWithMatrix.transform.right;
    }

    //public void loadCombinedMatrix(ref Matrix4x4 nodeMatrix)
    //{
    //    var position = nodeMatrix.GetColumn(3);
    //    gameObject.transform.position = position;
    //    Debug.Log("Transform position from matrix is: " + position);
    //}

    public void ObtainCurrentNode(Transform Xform)
    {
        if(Xform != null)
        {
            nodeWithMatrix = GameObject.Find(Xform.name);
            nodeScript = nodeWithMatrix.GetComponent<SceneNode>();
        }
    }
}
