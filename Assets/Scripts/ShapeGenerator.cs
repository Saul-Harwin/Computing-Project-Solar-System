using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeGenerator : MonoBehaviour
{
    ShapeSettings settings;
    NoiseProcessor noiseProcessor;

    public CalculateMinMax elevationMinMax;


    public ShapeGenerator(ShapeSettings settings) {
        this.settings = settings;
        noiseProcessor = new NoiseProcessor(settings.noiseSettings);
        elevationMinMax = new CalculateMinMax();
    }

    public Vector3 CalculatePointOnPlanet(Vector3 pointOnUnitSphere)
    {
        float elevation = noiseProcessor.Evaluate(pointOnUnitSphere);
        elevation = settings.planetRadius * (1+elevation);
        elevationMinMax.AdjustMinMax(elevation);
        return pointOnUnitSphere * elevation;
    }

}
