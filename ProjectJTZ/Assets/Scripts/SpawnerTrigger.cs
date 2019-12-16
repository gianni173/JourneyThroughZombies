using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTrigger : MonoBehaviour
{

    public List<GameObject> spawnerList;

    public void ActivateSpawns()
    {
        foreach(GameObject go in spawnerList)
        {
            go.SetActive(true);
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" || other.tag == "Camper")
        {
            ActivateSpawns();
        }
    }
}
