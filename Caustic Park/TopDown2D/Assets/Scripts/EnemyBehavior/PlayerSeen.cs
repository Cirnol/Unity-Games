using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSeen : MonoBehaviour
{
    [SerializeField] private Hero hero;
    [SerializeField] private List<FOV> fovs;
    [SerializeField] Material start;
    [SerializeField] Material triggered;
    private Renderer render;

    private void Start()
    {
        render = GetComponent<Renderer>();
        hero = FindObjectOfType<Hero>();
    }

    void Update()
    {
        foreach (FOV fov in fovs)
        {
            if(fov.IsPlayerSeen(hero.transform))
            {
                render.material = triggered;
                return;
            }
        }
        render.material = start;
    }
}
