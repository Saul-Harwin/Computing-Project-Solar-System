using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityEffector : MonoBehaviour
{
    public GameObject player;
    public float G;

    public void Effector(GameObject planet, float distance) {
        distance *= 1000f; // Turn it into meters
        this.G = 6.67408e+27f;
        float playerMass = player.GetComponent<Rigidbody>().mass * 1e-15f * 1.00e-07f;
        float planetMass = planet.GetComponent<Rigidbody>().mass;
        Vector3 forceDirection = (player.GetComponent<Rigidbody>().position - planet.GetComponent<Rigidbody>().position).normalized;
        Vector3 force = forceDirection * G * (playerMass * planetMass) / ((distance) * distance);
        player.GetComponent<Rigidbody>().AddForce(-force);
    }
}
