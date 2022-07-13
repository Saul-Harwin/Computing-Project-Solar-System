using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [Tooltip("2 Cameras")]
    public GameObject playerCamera;
    public GameObject mapCamera;

    [Tooltip("Is the player on Map View?")]
    public bool onMap;

    [Tooltip("Is the Game Paused?")]
    public bool paused;

    void Start() {
        onMap = true;
        paused = true;
        playerCamera.GetComponent<Camera>().enabled = false;
        mapCamera.GetComponent<Camera>().enabled = true;
    }

    void Update() {
        if (Input.GetKeyDown("m")) {
            ToggleOnMap();
            TogglePaused();
        }
        if (Input.GetKeyDown(KeyCode.Escape) && !onMap) {
            TogglePaused();
        }
    }

    public void ToggleOnMap() {
        Debug.Log("Map:");
        Debug.Log(onMap);
        playerCamera.GetComponent<Camera>().enabled = !playerCamera.GetComponent<Camera>().enabled;
        mapCamera.GetComponent<Camera>().enabled = !mapCamera.GetComponent<Camera>().enabled;

        onMap = !onMap;
    }

    public void TogglePaused() {
        print("Paused:");
        print(paused);
        if (paused) {
                Time.timeScale = 1;
                paused = false;
            } 
            else {
                Time.timeScale = 0;
                paused = true;
        }
    }
}
