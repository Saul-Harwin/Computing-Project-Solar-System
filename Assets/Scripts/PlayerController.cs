using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    PlayerState playerState;
    Rigidbody rb;
    public float mouseSensitivity;
    public float thrustSensitivity;
    public float rotationSensitivity;
    public Transform player;
    public Transform camera;
    float xRotation = 0f;
    public Vector3 velocity;

    void Start() {
        playerState = player.GetComponent<PlayerState>();
        rb = player.GetComponent<Rigidbody>();
        // Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
        if (!playerState.onMap && !playerState.paused) {
            if (Input.GetKey("space"))
            {
                rb.AddForce(-Vector3.up * thrustSensitivity);
            }
            // if (Input.GetKey(KeyCode.LeftShift))
            // {
            //     rb.AddForce(-player.up * thrustSensitivity);
            //     print("Shift");
            // }
            if (Input.GetKey("w")) {
                player.transform.Rotate(Vector3.forward * rotationSensitivity);
            }
            if (Input.GetKey("s")) {
                player.transform.Rotate(Vector3.back * rotationSensitivity);
            }
            if (Input.GetKey("d")) {
                player.transform.Rotate(Vector3.right * rotationSensitivity);
            }
            if (Input.GetKey("a")) {
                player.transform.Rotate(Vector3.left * rotationSensitivity);
            }
            if (Input.GetKey(KeyCode.LeftShift)){
                rb.drag = 10;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift)) {
                rb.drag = 0;
            }

            // Mouse
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            camera.Rotate(Vector3.left * mouseY);
            camera.Rotate(Vector3.up * mouseX);
        }
    }
}