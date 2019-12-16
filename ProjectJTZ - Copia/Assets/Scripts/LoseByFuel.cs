using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseByFuel : MonoBehaviour
{

    public GameController fuelReference;
    public GameEvent loseByFuelEvent;
    public GameObject fuelRes;

    bool lost = false;

    private void FixedUpdate()
    {
        if (fuelReference.camperFuel <= 0 && !lost)
            CheckForFuel();
    }

    void CheckForFuel()
    {
        GameObject[] spawners = GameObject.FindGameObjectsWithTag("ResSpawner");
        foreach(GameObject go in spawners)
        {
            if (go.GetComponent<SpawnerRisorse>().risorsa == fuelRes && go.GetComponent<SpawnerRisorse>().spawnTimes > 0)
                return;
        }

        lost = true;
        loseByFuelEvent.Raise();
    }

}
