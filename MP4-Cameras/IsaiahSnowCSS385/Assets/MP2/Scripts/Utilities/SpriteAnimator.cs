using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    private SpriteRenderer sprite;
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private float timer = .25f;
    private float t;
    private int index = 0;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = sprites[index++];
        t = timer;
    }

    private void Update()
    {
        if(t < 0)
        {
            SwapSprite();
            t = timer;
        }

        t -= Time.deltaTime;
    }

    private void SwapSprite()
    {
        sprite.sprite = sprites[index];

        index = (index + 1) % sprites.Count;
    }

    private void OnEnable()
    {
        sprite.enabled = true;
    }

    private void OnDisable()
    {
        sprite.enabled = false;
    }
}
