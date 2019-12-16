using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRisorse : MonoBehaviour
{
    public GameObject risorsa;
    public float spawnTime = 3f;
    public int spawnNumberMin = 1;
    public int spawnNumberMax = 2;
    public int spawnTimes = 10;
    public float TimerSpawner;

    [HideInInspector]
    public bool isSpawned = false;

    int maxTimes;
    float t;
    GameObject spawned;
    List<GameObject> risorsaSpawn;

    void Start ()
    {
        maxTimes = spawnTimes;
        t = TimerSpawner;
    }

    void Update ()
    {
        IsLooted();

        if (!isSpawned)
        {
            t -= Time.deltaTime;

            if (t <= 0 && spawnTimes > 0)
            {
                t = spawnTime;
                spawnTimes--;
                Spawn();
            }
        }
    }

    public void Spawn()
    {
        spawned = Instantiate(risorsa, new Vector3( transform.position.x, 0.08f, transform.position.z), transform.rotation);
        PickUpRisorse script = spawned.GetComponent<PickUpRisorse>();
        script.quantity = Random.Range(spawnNumberMin, spawnNumberMax + 1);
        script.maxSpawns = maxTimes;
        script.spawnRemained = spawnTimes;
        isSpawned = true;
    }

    void IsLooted()
    {
        if (spawned == null)
            isSpawned = false;
    }
}
