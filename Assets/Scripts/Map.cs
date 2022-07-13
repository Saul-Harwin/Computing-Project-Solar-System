using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {
    public GameObject player;
    PlayerState playerState;
    public float zoom;
    public Camera MainCamera;

    void Start() {
        playerState = player.GetComponent<PlayerState>(); 
    }

    void Update() {
        GetComponent<Camera>().orthographicSize = zoom;

        if (playerState.onMap) {    
            if (Input.GetKey("w")) {
                transform.Translate(Vector3.up * (zoom/100));
            }
            if (Input.GetKey("s")) {
                transform.Translate(Vector3.down * (zoom/100));
            }
            if (Input.GetKey("a")) {
                transform.Translate(Vector3.left * (zoom/100));
            }
            if (Input.GetKey("d")) {
                transform.Translate(Vector3.right * (zoom/100));
            }
            if (Input.GetKey("space")) {
                zoom *= 1.01f;
            }
            if (Input.GetKey(KeyCode.LeftShift)) {
                zoom *= 0.99f;
            }
        }
    }
}
