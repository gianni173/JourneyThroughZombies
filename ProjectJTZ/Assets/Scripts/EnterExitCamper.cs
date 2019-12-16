using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterExitCamper : MonoBehaviour
{

    public SO_GameController gm;
    public SO_Input SO_input;
    public GameEvent SwitchToCombatEvent;
    public GameObject tower;
    public GameObject playerOnCamper;
    public GameObject player;
    public GameObject playerDescendPos;
    public GameEvent accensione;
    public GameEvent motore;
    public GameEvent spento;
    //public GameObject arrow;

    Rigidbody rb;
    bool canEnter = false;
    MovimentoCamperG camperScript;

    void Start()
    {
        camperScript = GetComponent<MovimentoCamperG>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (gm.mode == "ONCAMPER")
        {
            if (Input.GetKeyDown(SO_input.interazione) && camperScript.acceleration == 0)
            {
                rb.constraints = RigidbodyConstraints.FreezeAll;
                gm.mode = "ONGROUND";
                playerOnCamper.GetComponent<Renderer>().enabled = false;
                tower.GetComponent<AimToMouse>().enabled = false;
                camperScript.enabled = false;
                player.transform.position = playerDescendPos.transform.position;
                // playerComponents
                player.GetComponent<Renderer>().enabled = true;
                Renderer[] allRenderers = player.GetComponentsInChildren<Renderer>();
                foreach (Renderer rnd in allRenderers)
                {
                    rnd.enabled = true;
                }
                player.GetComponent<AimToMouse>().enabled = true;
                player.GetComponent<Collider>().enabled = true;
                player.GetComponent<Rigidbody>().velocity = Vector3.zero;
                spento.Raise();

            }
        }
        else if (gm.mode == "ONGROUND")
        {
            //mostra che puoi salire premendo E
            if (Input.GetKeyDown(SO_input.interazione) && gm.mode == "ONGROUND" && canEnter)
            {
                rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                gm.mode = "ONCAMPER";
                gm.playerMode = "COMBAT";
                SwitchToCombatEvent.Raise();
                playerOnCamper.GetComponent<Renderer>().enabled = true;
                camperScript.enabled = true;
                tower.GetComponent<AimToMouse>().enabled = true;
                // playerComponents
                player.GetComponent<Renderer>().enabled = false;
                Renderer[] allRenderers = player.GetComponentsInChildren<Renderer>();
                foreach(Renderer rnd in allRenderers)
                {
                    rnd.enabled = false;
                }
                player.GetComponent<AimToMouse>().enabled = false;
                player.GetComponent<Collider>().enabled = false;
                StartCoroutine("AccensioneCamper");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            canEnter = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            canEnter = false;
    }
    IEnumerator AccensioneCamper()
    {
        accensione.Raise();
        yield return new WaitForSeconds(2f);
        if (gm.mode == "ONCAMPER")
        {
            motore.Raise();
        }
    }
}
