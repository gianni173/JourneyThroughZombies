using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : MonoBehaviour
{

    public SO_GameController SO_gameController;
    public SO_StatisticheZombie SO_statZ;

    [HideInInspector]
    public GameObject target;

    GameObject player;
    GameObject camper;

    NavMeshAgent navMeshAgent;

    private void OnEnable()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = SO_statZ.speed;
        camper = GameObject.FindGameObjectWithTag("Camper");
        player = GameObject.FindGameObjectWithTag("Player");
        SearchTarget();
    }

    void Update ()
    {
        transform.LookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z));
        transform.Rotate(Vector3.right, 90);
        transform.Rotate(Vector3.forward, 90);

        //NavMesh Destination
        if (navMeshAgent.enabled)
            SetDestination();
    }

    public void SearchTarget()
    {
        if (SO_gameController.mode == "ONGROUND")
            target = player;
        else
            target = camper;
    }

    public void FocusPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = player;
    }

    public void FocusCamper()
    {
        camper = GameObject.FindGameObjectWithTag("Camper");
        target = camper;
    }

    public void SetDestination()
    {
        if(target != null)
        {
            navMeshAgent.SetDestination(target.transform.position);
        }
    }
}
