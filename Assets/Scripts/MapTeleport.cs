using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class MapTeleport : MonoBehaviour {
    GameObject player;
    public GameObject CelestialBodies;
    Vector3 dst; 
    Vector3 velocity;

    public void Teleport(string planetName) {
        player = GameObject.Find("Player");
        dst = GameObject.Find(planetName).transform.position + (GameObject.Find(planetName).transform.localScale / 2 ) + new Vector3(100f, 100f, 100f);
        player.transform.position = dst; 
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
