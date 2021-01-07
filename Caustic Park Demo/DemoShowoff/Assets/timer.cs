using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public float time = 0.0f;
    private Text myText; 
    // Start is called before the first frame update

    void Start()
    {
        myText = GetComponent<Text>();
    }
    void Update()
    {
        time += Time.deltaTime;
        myText.text = time.ToString();
    }
}
