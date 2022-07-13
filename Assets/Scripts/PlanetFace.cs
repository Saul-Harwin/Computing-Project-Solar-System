using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlanetFace : MonoBehaviour
{
    ShapeGenerator shapeGenerator;
    Mesh mesh;
    int resolution; // Number of vertices along a single edge of one face.
    Vector3 localUp;
    Vector3 axisA;
    Vector3 axisB;

    public PlanetFace(ShapeGenerator shapeGenerator, Mesh mesh, int resolution, Vector3 localUp)
    {
        this.shapeGenerator = shapeGenerator;
        this.mesh = mesh;
        this.resolution = resolution;
        this.localUp = localUp;

        axisA = new Vector3(localUp.y, localUp.z, localUp.x); // Swap the x-->y the y-->z and the z-->x.
        axisB = Vector3.Cross(localUp, axisA); // Vecotr that is perpedicular to axisA and localUp vectors
    }

    public void ConstructMesh()
    {
        Vector3[] vertices = new Vector3[resolution * resolution];
        int[] triangles = new int[(resolution - 1) * (resolution - 1) * 6];
        int triIndex = 0;

        for (var y = 0; y < resolution; y++) // Creates the vertices.
        {
            for (var x = 0; x < resolution; x++)
            {
                int i = x + y * resolution; // Finds the index.
                Vector2 percent = new Vector2(x, y) / (resolution - 1); // Shows how close to completion the 2 loops together are. Is used to define where the vertex should be along the face.
                Vector3 pointOnUnitCube = localUp + (percent.x - 0.5f) * 2 * axisA + (percent.y - .5f) * 2 * axisB;
                Vector3 pointOnUnitSphere = pointOnUnitCube.normalized; // Normalises the point on unit cube to be a sphere.
                vertices[i] = shapeGenerator.CalculatePointOnPlanet(pointOnUnitSphere);

                if (x != resolution - 1 && y != resolution - 1) // As long as the vertex is not along the right or buttom edge of the Face.
                {
                    triangles[triIndex] = i;
                    triangles[triIndex + 1] = i + resolution + 1;
                    triangles[triIndex + 2] = i + resolution;

                    triangles[triIndex + 3] = i;
                    triangles[triIndex + 4] = i + 1;
                    triangles[triIndex + 5] = i + resolution + 1;
                    triIndex += 6;
                }
            }
        }

        // Update mesh with the data.
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }

}