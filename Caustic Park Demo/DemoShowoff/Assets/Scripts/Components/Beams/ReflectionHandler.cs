using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectionHandler : MonoBehaviour
{
    public ReflectBeam beams;
    public Collider2D col;
    public BeamFOVHandler handler;

    private void Awake()
    {
        beams.col = col;
        beams.myHandler = this;
        handler = FindObjectOfType<BeamFOVHandler>();
    }

    public void AddBeam(BeamFOV.Beam ray1, BeamFOV.Beam ray2)
    {
        beams.AddBeam(ray1, ray2);
    }
}
