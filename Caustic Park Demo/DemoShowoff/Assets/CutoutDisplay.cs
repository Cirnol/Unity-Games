using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutoutDisplay : MonoBehaviour
{
    private Vector3 offScreen;
    private Vector3 onScreen;

    private float onScreenTimer = 0.0f;
    private float maxOnScreen = 3.0f;

    private bool goingIn = true;
    private bool newCutout = false;
    public List<Vector3> cutouts = new List<Vector3>();
    private Text text;
    private GameObject extra;

    // Start is called before the first frame update
    void Start()
    {
        //offScreen = transform.localPosition;
        //onScreen = transform.localPosition;
        //onScreen.x += -320;
        text = GetComponentInChildren<Text>();
        extra = GameObject.Find("AnExtraName");
        extra.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (newCutout)
        {
            Debug.Log("new Cutout");
            text.text = "Found " + cutouts.Count.ToString() + "/30 Cutouts";
            onScreenTimer += Time.deltaTime;
            if(onScreenTimer < maxOnScreen)
            {
                extra.SetActive(true);
            }
            else
            {
                onScreenTimer -= maxOnScreen;
                newCutout = false;
                extra.SetActive(false);
            }
            //if (goingIn)
            //{
            //    transform.localPosition = Vector3.Lerp(transform.localPosition, onScreen, 0.05f);
            //    onScreenTimer += Time.deltaTime;
            //    if (onScreenTimer > maxOnScreen)
            //    {
            //        onScreenTimer -= maxOnScreen;
            //        goingIn = false;
            //    }
            //}
            //else
            //{
            //    transform.localPosition = Vector3.Lerp(transform.localPosition, offScreen, 0.025f);
            //}
            //if (Mathf.Abs(transform.localPosition.x - offScreen.x) < 1)
            //{
            //    transform.localPosition = offScreen;
            //    goingIn = true;
            //    newCutout = false;
            //}
        }
    }

    public void addCutout(GameObject cutout)
    {
        if (!cutouts.Contains(cutout.transform.position))
        {
            cutouts.Add(cutout.transform.position);
            newCutout = true;
        }
    }
}
