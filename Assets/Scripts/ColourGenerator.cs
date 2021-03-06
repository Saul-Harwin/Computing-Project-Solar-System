using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourGenerator : MonoBehaviour
{
    ColourSettings settings;
    Texture2D texture;
    const int textureResolution = 50;

    public ColourGenerator(ColourSettings settings) {
        this.settings = settings;
        texture = new Texture2D(textureResolution, 1);
    }

    public void UpdateElevation(CalculateMinMax elevationMinMax) {
        settings.planetMaterial.SetVector("_elevationMinMax", new Vector4(elevationMinMax.Min, elevationMinMax.Max));
    }

    public void UpdateColours() {
        Color[] colours = new Color[textureResolution];
        for (var i = 0; i < textureResolution; i++)
        {
            colours[i] = settings.gradient.Evaluate(i / (textureResolution - 1f));
        }
        texture.SetPixels(colours);
        texture.Apply();
        settings.planetMaterial.SetTexture("_texture", texture); 
    }
}
