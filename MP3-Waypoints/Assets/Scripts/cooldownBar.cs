using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static heroBlasting;

public class cooldownBar : MonoBehaviour
{
    private float cdY;
    private float cdZ;

    // Start is called before the first frame update
    void Start()
    {
        cdY = gameObject.transform.localScale.y;
        cdZ = gameObject.transform.localScale.z;
    }

    // Update is called once per frame
    void Update()
    {
        float ratio = cooldown / blastingRate; // Ratio needed so the bar matches the time left.
        gameObject.transform.localScale = new Vector3(Mathf.Clamp(ratio, 0f, 1f), cdY, cdZ);
        // Clamping makes it so the scale on X can only go from 0-1
    }

    // Cooldown bar code obtained from: https://answers.unity.com/questions/1105839/decreasing-a-bar-over-time.html
}
