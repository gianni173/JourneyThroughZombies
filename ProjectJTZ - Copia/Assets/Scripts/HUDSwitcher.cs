using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDSwitcher : MonoBehaviour
{

    public GameObject boostSystem;
    public GameObject buildingSystem;

    public bool canSeeBoost = false;
    public bool canSeeBuilding = false;

    public void SwitchToBoost()
    {
        if(canSeeBoost)
            boostSystem.SetActive(true);
        buildingSystem.SetActive(false);
    }

    public void SwitchToBuilding()
    {
        boostSystem.SetActive(false);
        if(canSeeBuilding)
            buildingSystem.SetActive(true);
    }

    public void CanSeeBoostNow()
    {
        canSeeBoost = true;
    }

    public void CanSeeBuildingNow()
    {
        canSeeBuilding = true;
    }
}
