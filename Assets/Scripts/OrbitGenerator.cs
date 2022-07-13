using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitGenerator : MonoBehaviour {
    public double orbitalSpeed;
    public double orbitalAngle;
    float radius;
    float timeCounter; 
    public string parent;
    GameObject parentObject;

    void Start() {
        parentObject = GameObject.Find(parent);
        timeCounter = 0;
    }

    void Update () {
        radius = Vector2.Distance (new Vector2 (transform.localPosition.x, transform.localPosition.z), new Vector2 (parentObject.transform.localPosition.x, parentObject.transform.localPosition.z));
        timeCounter += Time.deltaTime * (float)orbitalSpeed;
        float x = Mathf.Cos (timeCounter) * radius;
        float y = Mathf.Sin (timeCounter) * (radius * Mathf.Sin(Mathf.PI * (float)orbitalAngle / 180)); // Mathf.Sin takes in radians so you need to convert to degree before inputing the values.
        float z = Mathf.Sin (timeCounter) * radius;
        transform.localPosition = new Vector3 (x, y, z);
    }
}

