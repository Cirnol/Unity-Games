using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelingObj : MonoBehaviour
{
    float mSpeed;
    Vector3 mDir;
    float mTimeAlive;
    float mMaxLengthAlive;
    public GameObject myPlane;
    private Vector3 v;
    private float dp;


    // Start is called before the first frame update
    void Start()
    {
        mSpeed = 1f;  // How fast to travel in unit of per second
        mDir = new Vector3(1, 1, 1);               // Always kept normalized
        
    }

    // Update is called once per frame
    void Update()
    {
        //mTimeAlive += Time.deltaTime;
        //if (mTimeAlive > mMaxLengthAlive)
        //    Destroy(transform.gameObject);
        v = gameObject.transform.position - myPlane.transform.position;
        dp = Vector3.Dot(gameObject.transform.position, myPlane.transform.position);
        transform.localRotation *= Quaternion.FromToRotation(transform.up, mDir);

        Debug.Log("Diatance from plane to obj: " + v.magnitude);
        Debug.Log("Diatance from plane to obj: " + v);

        if(dp > 0)
        {
            Debug.Log(dp + "is bigger");
        }
        else
        {
            Debug.Log(dp + "is smaller");
        }
    }
}
