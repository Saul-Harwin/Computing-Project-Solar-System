using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NoiseSettings
{
    [Range(1,8)]
    public int octaves = 1;
    public float lacunarity = 1.5f; // Meaning for each octave the frequecny increase by 1.5x.
    public float percistance = .5f; // Meaning for each octave the amplitude will be half.

    public float frequency = 1;
    public float amplitude = 1;
    public Vector3 offset;

    public float rededeIntoSphereStrength;
}
