using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitGenerator : MonoBehaviour {    
    public float orbitalSpeed;
    float timeCounter; 

    void Start() {
        timeCounter = 0;
    }

    void Update () {
        timeCounter += Time.deltaTime * (orbitalSpeed) ;
        float x = Mathf.Cos (timeCounter) + transform.position.x;
        float y = 0;
        float z = Mathf.Sin (timeCounter) + transform.position.z;
        transform.position = new Vector3 (x, y, z);
    }
}
