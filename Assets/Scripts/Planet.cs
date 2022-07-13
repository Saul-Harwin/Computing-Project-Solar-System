using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [Range(2, 256)]
    public int resolution = 10;

    public ShapeSettings shapeSettings;
    public ColourSettings colourSettings;

    [HideInInspector]
    public bool shapeSettingsFoldOut;
    [HideInInspector]
    public bool colourSettingsFoldOut;

    ShapeGenerator shapeGenerator;
    ColourGenerator colourGenerator;

    [SerializeField, HideInInspector] // Makes sure that they are hidden but still saved in the editor.
    MeshFilter[] meshFilters;
    PlanetFace[] planetFaces;

    void Initialize()
    {
        shapeGenerator = new ShapeGenerator(shapeSettings);
        colourGenerator = new ColourGenerator(colourSettings);
        if (meshFilters == null || meshFilters.Length == 0) // Only creates a new MeshFilter if there is no meshFilters in the array.
        {
            meshFilters = new MeshFilter[6];
        }
        planetFaces = new PlanetFace[6];

        Vector3[] directions = { Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.forward, Vector3.back };

        for (var i = 0; i < 6; i++)
        {
            if (meshFilters[i] == null)
            {
                GameObject meshObj = new GameObject("mesh");
                meshObj.transform.parent = transform;
                meshObj.AddComponent<MeshRenderer>();
                meshFilters[i] = meshObj.AddComponent<MeshFilter>();
                meshFilters[i].sharedMesh = new Mesh();
                meshObj.AddComponent<MeshCollider>();
                meshObj.GetComponent<MeshCollider>().sharedMesh = null;
                meshObj.GetComponent<MeshCollider>().sharedMesh = meshFilters[i].mesh;
                meshObj.GetComponent<MeshCollider>().convex = true;
                meshObj.transform.localPosition = new Vector3(0,0,0);
                meshObj.transform.localScale = new Vector3(1,1,1);
            }
            meshFilters[i].GetComponent<MeshRenderer>().sharedMaterial = colourSettings.planetMaterial;
            planetFaces[i] = new PlanetFace(shapeGenerator, meshFilters[i].sharedMesh, resolution, directions[i]);
        }
    }

    void Start() {
        GeneratePlanet();
    }

    public void GeneratePlanet() {
        Initialize();
        GenerateMesh();
        GenerateColours();
    }

    public void OnShapeSettingsUpdated() {
        Initialize();
        GenerateMesh();
    }

    public void OnColourSettingsUpdated() {
        Initialize();
        GenerateColours();
    }

    void GenerateMesh() // Loops through all Planet faces and constructs the mesh.
    {
        foreach (PlanetFace face in planetFaces)
        {
            face.ConstructMesh();
        }
        colourGenerator.UpdateElevation(shapeGenerator.elevationMinMax);
    }

    void GenerateColours() {
        colourGenerator.UpdateColours();
    }
}
