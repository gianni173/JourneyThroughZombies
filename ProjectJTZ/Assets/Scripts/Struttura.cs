using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Struttura : MonoBehaviour {

    public SO_Struttura statsMother;

    [HideInInspector]
    public SO_Struttura stats;

    public bool placed = false;
    List<GameObject> attackers;

    void Start()
    {
        attackers = new List<GameObject>();
        stats = Instantiate(statsMother);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (placed)
        {
            if (other.tag == "Zombie")
            {
                ZombieAttack script = other.GetComponent<ZombieAttack>();
                script.navMeshAgent.enabled = false;
                script.navMeshObst.enabled = true;
                script.targetedStructure = gameObject;
                script.attackingStructure = true;
                attackers.Add(other.gameObject);
            }
        }
    }

    public void ReactivateAttackers()
    {
        foreach (GameObject go in attackers)
        {
            ZombieAttack script = go.GetComponent<ZombieAttack>();
            script.attackingStructure = false;
            script.navMeshObst.enabled = false;
            script.navMeshAgent.enabled = true;
            go.GetComponent<ZombieMovement>().SearchTarget();
        }
    }

    public void SetPlaced()
    {
        placed = true;
    }
}
