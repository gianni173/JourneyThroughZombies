using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugInputs : MonoBehaviour {

    GameObject[] allSpawners;
    public GameController gm;
    public GameController gmValues;
    public Input SO_input;

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

        if (UnityEngine.Input.GetKeyDown(SO_input.debugSpawnZombieWave))
        {
            foreach (GameObject go in allSpawners)
            {
                go.GetComponent<ZombieSpawner>().SpawnAll();
            }
        }

        if (UnityEngine.Input.GetKeyDown(SO_input.debugGoToMenu))
        {
            SceneManager.LoadScene("Menu");
        }

        if (UnityEngine.Input.GetKeyDown(SO_input.debugStopStartSpawns))
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

        if (UnityEngine.Input.GetKey(SO_input.debugHealthCheat))
        {
            gm.camperFuel++;
            gm.playerHp++;
        }
    
        if (UnityEngine.Input.GetKey(SO_input.debugAmmoCheat))
        {
            gm.ammo++;
        }

        if (UnityEngine.Input.GetKeyDown(SO_input.debugResetGameController))
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
