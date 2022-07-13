using UnityEngine;
using System.Collections;

public class RocketControls : MonoBehaviour 
{
    PlayerState playerState;
    public GameObject player;
    public GameObject rocket;
    public float thrustMultiplier;
    public float rotationSpeed;
    private bool applyThrust = false;

    void Start () {
        playerState = player.GetComponent<PlayerState>();
    }

    // Check for misc keypresses
    void CheckMiscKeys ()
    {
        // Start applying thrust
        if (Input.GetKey (KeyCode.Space))
        {
            applyThrust = true;
        }

        // Stop applying thrust
        if (Input.GetKey (KeyCode.LeftShift))
        {
            applyThrust = false;
            if (Input.GetKey(KeyCode.LeftShift)){
                player.GetComponent<Rigidbody>().drag = 100;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift)) {
                player.GetComponent<Rigidbody>().drag = 0;
            }
        }
    }

    // Check for rotation keypresses
    void CheckRotationKeys ()
    {
        // Rotate forward
        if (Input.GetKey (KeyCode.W))
        {
            player.transform.Rotate (rotationSpeed * new Vector3 (0, 0, -1));
        }

        // Rotate backwards
        if (Input.GetKey (KeyCode.S))
        {
            player.transform.Rotate (rotationSpeed * new Vector3 (0, 0, 1));
        }

        // Rotate left
        if (Input.GetKey (KeyCode.A))
        {
            player.transform.Rotate (rotationSpeed * new Vector3 (-1, 0, 0));
        }

        // Rotate right
        if (Input.GetKey (KeyCode.D))
        {
            player.transform.Rotate (rotationSpeed * new Vector3 (1, 0, 0));
        }
    }

    // Apply thrust to the rocket's rigidbody
    void ApplyRocketThrust ()
    {
        if (applyThrust)
        {
            Vector3 force = rocket.transform.up * thrustMultiplier;
            player.GetComponent<Rigidbody>().AddForce(force);
        }
    }

    // Run physics calculations and misc events
    void FixedUpdate ()
    {
        print(Vector3.Magnitude(player.GetComponent<Rigidbody>().velocity) / 0.0000001f);
        if (!playerState.onMap && !playerState.paused) {
            CheckMiscKeys ();
            CheckRotationKeys ();
            ApplyRocketThrust ();
        }
    }
}