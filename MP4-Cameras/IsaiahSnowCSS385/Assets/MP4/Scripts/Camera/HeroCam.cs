using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCam : MonoBehaviour
{
    private ShakePosition shakePosition;
    private Vector3 origin;

    public float shakeFrequency;
    public float shakeDuration;
    public Vector2 shakeMagnitude;

    // Start is called before the first frame update
    void Start()
    {
        shakePosition = new ShakePosition(shakeFrequency, shakeDuration);
        origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z;
        float fade = Mathf.Min(8 * Time.smoothDeltaTime);
        origin = Vector3.Lerp(transform.position, mousePosition, fade);
        transform.position = origin + shakePosition.UpdateShake();
    }
    public void Shake()
    {
        shakePosition.SetShakeParameters(shakeFrequency, shakeDuration);
        shakePosition.SetShakeMagnitude(shakeMagnitude, new Vector3(0, 0, 0));
    }
}
