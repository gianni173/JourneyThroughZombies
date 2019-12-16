using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieStats : MonoBehaviour
{
    public StatisticheZombie SO_statZ;
    public GameObject ammoPack;
    bool droppato = false;

    [HideInInspector]
    public ZombieAnim anim;

    [HideInInspector]
    public float hp;

    private void Start()
    {
        hp = SO_statZ.hp;
        anim = GetComponent<ZombieAnim>();
    }

    void Update () {

        if(hp <= 0)
        {
            int rnd = Random.Range(0,100);
            GameObject spawned;
            ZombieAnim anim = GetComponent<ZombieAnim>();
            anim.Death();
            if (rnd <= SO_statZ.ammoDropPercent && SO_statZ.isDropper && droppato == false)
            {
                spawned = Instantiate(ammoPack, new Vector3(transform.position.x, 0.01f, transform.position.z), Quaternion.identity);
                spawned.transform.Rotate(Vector3.right, 90);
                spawned.transform.Rotate(Vector3.forward, Random.Range(0f, 360f));
            }
            droppato = true;

        }
        if (SO_statZ.striscia)
        {
            if (hp <= (SO_statZ.hp / 2) && !anim.isStrisciando)
            {
                anim.Crawling();
            }
        }
    }
}
