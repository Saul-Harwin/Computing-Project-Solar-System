using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseProcessor : MonoBehaviour
{
    NoiseSettings settings;
    Noise noise = new Noise();

    public NoiseProcessor(NoiseSettings settings) {
        this.settings = settings;
    }

    public float Evaluate(Vector3 point) {

        float noiseValue = 0;
        float frequency = settings.frequency;
        float amplitude = settings.amplitude;

        for (var o = 0; o < settings.octaves; o++)
        {
            float v = noise.Evaluate(point * frequency + settings.offset);
            noiseValue += (v+1) * 0.5f * amplitude;
            frequency *= settings.lacunarity;
            amplitude *= settings.percistance;
        }
        noiseValue = Mathf.Max(0, noiseValue-settings.rededeIntoSphereStrength);
        return noiseValue * settings.amplitude;
    }
}
