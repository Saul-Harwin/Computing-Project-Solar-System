using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    public float numStars;
    public Material starMaterial;
    System.Random r = new System.Random();

    void Start() {
        print(starMaterial);
        for (var i = 0; i < numStars; i++)  {
            Vector3 position = GenerateRandomVector();
            GameObject cubeObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            
            /*if you need add position, scale and color to the cube*/
            cubeObject.transform.localPosition = position;
            cubeObject.transform.localScale = new Vector3(1000, 1000, 1000);
            cubeObject.GetComponent<MeshRenderer>().material = starMaterial;
            
        }
    }

    Vector3 GenerateRandomVector() {
        int x = r.Next(-200000,200000);
        int y = r.Next(-200000,200000);
        int z = r.Next(-200000,200000);
        Vector3 position = new Vector3(x, y, z);
        if ((Vector3.Distance(new Vector3(0, 0, 0), position)) < 100000) {
            position = GenerateRandomVector();   
        }         
        return position;
    }
}
