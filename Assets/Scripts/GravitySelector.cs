using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class GravitySelector : MonoBehaviour {
    PlayerState playerState;
    public Transform player;
    public string firstPlanet;
    public string secondPlanet;

    void Start () {
        playerState = player.GetComponent<PlayerState>();
    }

    void Update() {
        Transform[] Planets = this.transform.GetComponentsInChildren<Transform>();
        List<Transform> children = new List<Transform>();
        foreach (Transform child in Planets) {
            switch(child.name) {
                case "Sun":
                    children.Add(child);
                    break;
                case "Mercury":
                    children.Add(child);
                    break;
                case "Venus":
                    children.Add(child);
                    break;
                case "Earth":
                    children.Add(child);
                    break;
                case "Moon":
                    children.Add(child);
                    break;
                case "Mars":
                    children.Add(child);
                    break;
                case "Jupiter":
                    children.Add(child);
                    break;
                case "Saturn":
                    children.Add(child);
                    break;  
                case "Uranus":
                    children.Add(child);
                    break;
                case "Neptune":
                    children.Add(child);
                    break;
                }
        }
        children = Sort(children);

        firstPlanet = children[0].name;
        secondPlanet = children[1].name;
        // this.GetComponent<GravityEffector>().Effector(GameObject.Find("Sun"), Vector3.Distance(GameObject.Find("Sun").transform.position, player.position));

        // this.GetComponent<GravityEffector>().Effector(GameObject.Find(firstPlanet), Vector3.Distance(children[0].transform.position, player.position));
        // this.GetComponent<GravityEffector>().Effector(GameObject.Find(secondPlanet), Vector3.Distance(children[1].transform.position, player.position));
        // this.GetComponent<GravityEffector>().Effector(GameObject.Find(children[2].name), Vector3.Distance(children[2].transform.position, player.position));
        // this.GetComponent<GravityEffector>().Effector(GameObject.Find(children[3].name), Vector3.Distance(children[3].transform.position, player.position));
        // this.GetComponent<GravityEffector>().Effector(GameObject.Find(children[4].name), Vector3.Distance(children[4].transform.position, player.position));
        // this.GetComponent<GravityEffector>().Effector(GameObject.Find(children[5].name), Vector3.Distance(children[5].transform.position, player.position));
        // this.GetComponent<GravityEffector>().Effector(GameObject.Find(children[6].name), Vector3.Distance(children[6].transform.position, player.position));
        // this.GetComponent<GravityEffector>().Effector(GameObject.Find(children[7].name), Vector3.Distance(children[7].transform.position, player.position));
        // this.GetComponent<GravityEffector>().Effector(GameObject.Find(children[8].name), Vector3.Distance(children[8].transform.position, player.position));
        // this.GetComponent<GravityEffector>().Effector(GameObject.Find(children[9].name), Vector3.Distance(children[9].transform.position, player.position));

        if (!playerState.onMap && !playerState.paused) {
            for (int i = 0; i <= 2; i++) {
                this.GetComponent<GravityEffector>().Effector(GameObject.Find(children[i].name), Vector3.Distance(GameObject.Find(children[i].name).transform.position, player.position));
            }
        }
    }

    List<Transform> Sort(List<Transform> children) {
        int n = children.Count, i, j, flag;
        Transform val;
        for (i = 1; i < n; i++) {
            val = children[i];
            flag = 0;
            for (j = i - 1; j >= 0 && flag != 1; ) {
                if (Vector3.Distance(val.transform.position, player.position) < Vector3.Distance(children[j].transform.position, player.position)) {
                    children[j + 1] = children[j];
                    j--;
                    children[j + 1] = val;
                } else flag = 1;
            }
        }
        return children;
    }
}
