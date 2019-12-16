using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackThis : MonoBehaviour
{

    public GameObject target;

    private void Start()
    {
        GetComponent<ZombieMovement>().target = target;
    }

    private void Update()
    {
        if(target == null)
        {
            GetComponent<ZombieMovement>().SearchTarget();
        }
    }

}
