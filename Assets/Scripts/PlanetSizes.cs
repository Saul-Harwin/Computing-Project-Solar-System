using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSizes : MonoBehaviour
{
    public void Do(double[] planetData) {
        Transform[] allChildren = this.transform.GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren) {
            switch(child.name) {
                case "Sun":
                    child.gameObject.transform.localScale = new Vector3((float)(planetData[10]), (float)(planetData[10]), (float)(planetData[10]));
                    child.gameObject.transform.localPosition = new Vector3((float)(planetData[20]), 0, 0);
                    child.gameObject.GetComponent<Rigidbody>().mass = (float)planetData[0];
                    break;
                case "Mercury":
                    child.gameObject.transform.localScale = new Vector3((float)(planetData[11]), (float)(planetData[11]), (float)(planetData[11]));
                    child.gameObject.transform.localPosition = new Vector3((float)(planetData[21]), 0, 0);
                    child.GetComponent<OrbitGenerator>().orbitalSpeed = planetData[31];
                    child.GetComponent<OrbitGenerator>().orbitalAngle = planetData[41];
                    child.GetComponent<OrbitGenerator>().parent = "Sun";
                    child.gameObject.GetComponent<Rigidbody>().mass = (float)planetData[1];
                    break;
                case "Venus":
                    child.gameObject.transform.localScale = new Vector3((float)(planetData[12]), (float)(planetData[12]), (float)(planetData[12]));
                    child.gameObject.transform.localPosition = new Vector3((float)(planetData[22]), 0, 0);
                    child.GetComponent<OrbitGenerator>().orbitalSpeed = planetData[32];
                    child.GetComponent<OrbitGenerator>().orbitalAngle = planetData[42];
                    child.GetComponent<OrbitGenerator>().parent = "Sun";
                    child.gameObject.GetComponent<Rigidbody>().mass = (float)planetData[2];
                    break;
                case "Earth":
                    child.gameObject.transform.localScale = new Vector3((float)(planetData[13]), (float)(planetData[13]), (float)(planetData[13]));
                    child.gameObject.transform.localPosition = new Vector3((float)(planetData[23]), 0, 0);
                    child.GetComponent<OrbitGenerator>().orbitalSpeed = planetData[33];
                    child.GetComponent<OrbitGenerator>().orbitalAngle = planetData[43];
                    child.GetComponent<OrbitGenerator>().parent = "Sun";
                    child.gameObject.GetComponent<Rigidbody>().mass = (float)planetData[3];
                    break;
                case "Moon":
                    child.gameObject.transform.localScale = new Vector3((float)(planetData[14]), (float)(planetData[14]), (float)(planetData[14])) / (float)(planetData[13]);
                    child.gameObject.transform.localPosition = new Vector3((float)(planetData[24]), 0, 0);
                    child.GetComponent<OrbitGenerator>().orbitalSpeed = planetData[34];
                    child.GetComponent<OrbitGenerator>().orbitalAngle = planetData[44];
                    child.GetComponent<OrbitGenerator>().parent = "Earth";
                    child.gameObject.GetComponent<Rigidbody>().mass = (float)planetData[4];
                    break;
                case "Mars":
                    child.gameObject.transform.localScale = new Vector3((float)(planetData[15]), (float)(planetData[15]), (float)(planetData[15]));
                    child.gameObject.transform.localPosition = new Vector3((float)(planetData[25]), 0, 0);
                    child.GetComponent<OrbitGenerator>().orbitalSpeed = planetData[35];
                    child.GetComponent<OrbitGenerator>().orbitalAngle = planetData[45];
                    child.GetComponent<OrbitGenerator>().parent = "Sun";
                    child.gameObject.GetComponent<Rigidbody>().mass = (float)planetData[5];
                    break;
                case "Jupiter":
                    child.gameObject.transform.localScale = new Vector3((float)(planetData[16]), (float)(planetData[16]), (float)(planetData[16]));
                    child.gameObject.transform.localPosition = new Vector3((float)(planetData[26]), 0, 0);
                    child.GetComponent<OrbitGenerator>().orbitalSpeed = planetData[36];
                    child.GetComponent<OrbitGenerator>().orbitalAngle = planetData[46];
                    child.GetComponent<OrbitGenerator>().parent = "Sun";
                    child.gameObject.GetComponent<Rigidbody>().mass = (float)planetData[6];
                    break;
                case "Saturn":
                    child.gameObject.transform.localScale = new Vector3((float)(planetData[17]), (float)(planetData[17]), (float)(planetData[17]));
                    child.gameObject.transform.localPosition = new Vector3((float)(planetData[27]), 0, 0);
                    child.GetComponent<OrbitGenerator>().orbitalSpeed = planetData[37];
                    child.GetComponent<OrbitGenerator>().orbitalAngle = planetData[47];
                    child.GetComponent<OrbitGenerator>().parent = "Sun";
                    child.gameObject.GetComponent<Rigidbody>().mass = (float)planetData[7];
                    break;
                case "Uranus":
                    child.gameObject.transform.localScale = new Vector3((float)(planetData[18]), (float)(planetData[18]), (float)(planetData[18]));
                    child.gameObject.transform.localPosition = new Vector3((float)(planetData[28]), 0, 0);
                    child.GetComponent<OrbitGenerator>().orbitalSpeed = planetData[38];
                    child.GetComponent<OrbitGenerator>().orbitalAngle = planetData[48];
                    child.GetComponent<OrbitGenerator>().parent = "Sun";
                    child.gameObject.GetComponent<Rigidbody>().mass = (float)planetData[8];
                    break;
                case "Neptune":
                    child.gameObject.transform.localScale = new Vector3((float)(planetData[19]), (float)(planetData[19]), (float)(planetData[19]));
                    child.gameObject.transform.localPosition = new Vector3((float)(planetData[29]), 0, 0);
                    child.GetComponent<OrbitGenerator>().orbitalSpeed = planetData[39];
                    child.GetComponent<OrbitGenerator>().orbitalAngle = planetData[49];
                    child.GetComponent<OrbitGenerator>().parent = "Sun";
                    child.gameObject.GetComponent<Rigidbody>().mass = (float)planetData[9];
                    break;
            }
        }
    }
}
