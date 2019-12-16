using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchModeGrndCamp : MonoBehaviour {

    public GameController gm;
    public GameObject tower;
    public GameObject playerOnCamper;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gm.mode = "ONCAMPER";
            playerOnCamper.GetComponent<Renderer>().enabled = true;
            other.GetComponent<Renderer>().enabled = false;
            other.GetComponent<AimToMouse>().enabled = false;
            Renderer[] allrenderers = other.GetComponentsInChildren<Renderer>();
            foreach (Renderer rnd in allrenderers)
                rnd.enabled = false;
            tower.GetComponent<AimToMouse>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            gm.mode = "ONGROUND";
            playerOnCamper.GetComponent<Renderer>().enabled = false;
            other.GetComponent<Renderer>().enabled = true;
            other.GetComponent<AimToMouse>().enabled = true;
            Renderer[] allrenderers = other.GetComponentsInChildren<Renderer>();
            foreach (Renderer rnd in allrenderers)
                rnd.enabled = true;
            tower.GetComponent<AimToMouse>().enabled = false;
        }
    }
}
