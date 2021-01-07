using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/RandomSound", order = 1)]
public class RandomSound : ScriptableObject
{
    public List<AudioClip> sounds;

    public AudioClip randomSound()
    {
        return sounds[Random.Range(0, sounds.Count)];
    }
}
