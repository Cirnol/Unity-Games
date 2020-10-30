using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public EggMovement egg;

    [SerializeField] private AudioSource rotateAudio;
    [SerializeField] private AudioSource arnoldAudio;

    [SerializeField] private Image image;

    [SerializeField] private Camera cam;

    [SerializeField] private float ArnoldStart = 4.1f;
    private bool playing = false;
    private bool wasPlaying = false;
    private bool arnold = false;

    private void Start()
    {
        rotateAudio.Stop();
        image.gameObject.SetActive(true);
    }

    private void Update()
    {
        playing = egg.isRotating;

        if (playing != wasPlaying)
        {
            if(playing)
            {
                rotateAudio.Play();
            }
            else
            {
                rotateAudio.Stop();
            }

            wasPlaying = playing;
        }

        cam.backgroundColor = Color.Lerp(Color.blue, Color.white, egg.GetValue());
        Color newColor = image.color;
        float newValue = egg.GetValue();
        if(newValue >= .75)
        {
            newColor.a = (newValue - .75f) / .2f;
            if(!arnold && !arnoldAudio.isPlaying)
            {
                arnold = true;
                arnoldAudio.time = ArnoldStart;
                arnoldAudio.Play();
            }
        }
        else
        {
            newColor.a = 0;
            arnold = false;
        }

        if(arnoldAudio.isPlaying && arnoldAudio.time > 5.7)
        {
            arnoldAudio.Stop();
        }
        image.color = newColor;
    }
}
