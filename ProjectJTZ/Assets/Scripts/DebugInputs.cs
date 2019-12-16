using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugInputs : MonoBehaviour {

    GameObject[] allSpawners;
    public SO_GameController gm;
    public SO_GameController gmValues;
    public SO_Input SO_input;

    public float percScraps = 100;
    public float percFood = 100;
    public float percAmmo = 100;
    public float percFuel = 100;
    public float percPlayerHp = 100;

    bool spawnsStopped = false;

    private void Start()
    {
        allSpawners = GameObject.FindGameObjectsWithTag("ZombieSpawner");
        ResetGMValues();
    }

    void Update () {

        if (Input.GetKeyDown(SO_input.debugSpawnZombieWave))
        {
            foreach (GameObject go in allSpawners)
            {
                go.GetComponent<ZombieSpawner>().SpawnAll();
            }
        }

        if (Input.GetKeyDown(SO_input.debugGoToMenu))
        {
            SceneManager.LoadScene("Menu");
        }

        if (Input.GetKeyDown(SO_input.debugStopStartSpawns))
        {
            if (spawnsStopped == false)
            {
                foreach (GameObject go in allSpawners)
                {
                    go.GetComponent<ZombieSpawner>().enabled = false;
                }
                spawnsStopped = true;
            }
            else
            {
                foreach (GameObject go in allSpawners)
                {
                    go.GetComponent<ZombieSpawner>().enabled = true;
                }
                spawnsStopped = false;
            }
        }

        if (Input.GetKey(SO_input.debugHealthCheat))
        {
            gm.camperFuel++;
            gm.playerHp++;
        }
    
        if (Input.GetKey(SO_input.debugAmmoCheat))
        {
            gm.ammo++;
        }

        if (Input.GetKeyDown(SO_input.debugResetGameController))
        {
            ResetGMValues();
        }
    }

    public void ResetGMValues()
    {
        gm.ammo = (int)(gmValues.ammo * Percentage(percAmmo));
        gm.camperFuel = gmValues.camperFuel * Percentage(percFuel);
        gm.playerHp = gmValues.playerHp * Percentage(percPlayerHp);
        gm.food = (int)(gmValues.food * Percentage(percFood));
        gm.scraps = (int)(gmValues.scraps * Percentage(percScraps));
        gm.mode = gmValues.mode;
        gm.playerMode = gmValues.playerMode;
        gm.FuelConsumption = gmValues.FuelConsumption;
    }

    float Percentage(float value)
    {
        float perc = 0;
        perc = value / 100;
        return perc;
    }
}
