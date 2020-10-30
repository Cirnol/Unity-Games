using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserStatus : MonoBehaviour
{
    [SerializeField] private Image bar;
    [SerializeField] private Hero hero;
    private float value = 0;
    private float startX;

    private void Awake()
    {
        if(bar == null)
        {
            bar = GetComponent<Image>();
        }

        startX = bar.rectTransform.sizeDelta.x;

        if (hero == null)
        {
            hero = FindObjectOfType<Hero>();
        }
    }

    private void Update()
    {
        value = hero.fireBar;
        Vector2 size = bar.rectTransform.sizeDelta;
        size.x = value * startX;
        bar.rectTransform.sizeDelta = size;
    }
}
