using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{

    public GameObject zombie;
    public float spawnTime = 1f;
    public int spawnNumber = 1;
    public int spawnTimes = 10;
    public float TimerSpawner;
    public IntVariable sceneWinSum;
    public GameEvent CheckSumEvent;

    [HideInInspector]
    public int maxSpawnTimes;

    float t;

    private void Start()
    {
        maxSpawnTimes = spawnTimes;
        t = TimerSpawner;
    }

    void Update () {

        t -= Time.deltaTime;

        if(t <= 0 && spawnTimes > 0)
        {
            SpawnAll();
            t = spawnTime;
            spawnTimes--;
        }

	}

    public void SpawnAll()
    {
        for (int i = 0; i < spawnNumber; i++)
        {
            Spawn();
        }
        if (sceneWinSum != null)
        {
            sceneWinSum.variable--;
            CheckSumEvent.Raise();
        }
    }

    public void Spawn()
    {
        Instantiate(zombie, transform.position, transform.rotation);
    }
}
