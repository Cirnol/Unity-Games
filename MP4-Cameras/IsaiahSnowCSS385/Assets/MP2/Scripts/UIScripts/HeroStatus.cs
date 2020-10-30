using UnityEngine;
using UnityEngine.UI;

public class HeroStatus : MonoBehaviour
{
    [SerializeField] private Hero hero;
    private Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    private void Update()
    {
        text.text = "Controls: " + hero.Controls
                  + "\nTouched Enemy Count: " + hero.EnemyTouched
                  + "\nHit: " + hero.EnemyHit;
    }
}
