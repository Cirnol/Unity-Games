using UnityEngine;
using UnityEngine.UI;

public class EggStatus : MonoBehaviour
{
    private Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    private void Update()
    {
        text.text = "Current Laser Count: " + Egg.GetEggCount();
    }
}
