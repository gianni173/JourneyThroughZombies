using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAttack : MonoBehaviour
{
    public GameEvent cameraShakeDirectHit;
    public FloatVariable shakeStrenght;
    public StatisticheZombie SO_statZ;
    public StatisticheCamper SO_statCamper;
    public GameController gm;
    public AudioClipTemplate clipPlayerColpito;
    public AudioClipTemplate clipCamperColpito;
    public GameEvent LoseEvent;
    public GameEvent ShakeCamera;

    [HideInInspector]
    public AudioSource audioPlayer;
    [HideInInspector]
    public NavMeshObstacle navMeshObst;
    [HideInInspector]
    public NavMeshAgent navMeshAgent;
    [HideInInspector]
    public GameObject targetedStructure;
    [HideInInspector]
    public bool attackingStructure = false;

    float t = 0;

    private void OnEnable()
    {
        audioPlayer = GameObject.Find("SFX OneShot").GetComponent<AudioSource>();
        navMeshObst = GetComponent<NavMeshObstacle>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        t -= Time.deltaTime;

        if (attackingStructure && t <= 0)
        {
            AttackStructure();
            t = SO_statZ.attackTimerSec;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player" || (collision.collider.tag == "Camper" && gm.mode == "ONCAMPER") || collision.collider.tag == "Esca")
        {
            navMeshAgent.enabled = false;
            navMeshObst.enabled = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Player" && t <= 0)
        {
            t = SO_statZ.attackTimerSec;
            shakeStrenght.variable = (SO_statZ.damage)/3;
            cameraShakeDirectHit.Raise();
            gm.playerHp -= SO_statZ.damage;
            audioPlayer.PlayOneShot(clipPlayerColpito.audio, clipPlayerColpito.volumeAudio);

            if (gm.playerHp <= 0f)
                LoseEvent.Raise();

        }
        if (collision.collider.tag == "Camper" && t <= 0 && gm.mode == "ONCAMPER")
        {
            t = SO_statZ.attackTimerSec;
            shakeStrenght.variable = (SO_statZ.damage * ((100 - SO_statCamper.resistence) / 100)) / 3;
            cameraShakeDirectHit.Raise();
            gm.playerHp -= SO_statZ.damage * ((100 - SO_statCamper.resistence) / 100);
            audioPlayer.PlayOneShot(clipCamperColpito.audio, clipCamperColpito.volumeAudio);
            if (gm.playerHp <= 0f)
                LoseEvent.Raise();

        }
        if (collision.collider.tag == "Esca" && t <= 0)
        {
            StatEsca script = collision.collider.gameObject.GetComponent<StatEsca>();
            t = SO_statZ.attackTimerSec;
            script.hp -= SO_statZ.damage;
            if (script.hp <= 0)
            {
                foreach(GameObject go in script.zombieAggrati)
                {
                    ZombieAttack za = go.GetComponent<ZombieAttack>();
                    za.navMeshObst.enabled = false;
                    za.navMeshAgent.enabled = true;
                    go.GetComponent<ZombieMovement>().SearchTarget();
                }
                Destroy(collision.collider.gameObject);
            }

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player" || collision.collider.tag == "Camper" || collision.collider.tag == "Esca")
        {
            navMeshObst.enabled = false;
            navMeshAgent.enabled = true;
        }
    }

    void AttackStructure()
    {
        Struttura structure = targetedStructure.GetComponent<Struttura>();
        structure.stats.hp -= SO_statZ.damage;
        if (structure.stats.hp < 0)
        {
            //attackingStructure = false;
            //navMeshObst.enabled = false;
            //navMeshAgent.enabled = true;
            //GetComponent<ZombieMovement>().SearchTarget();
            structure.ReactivateAttackers();
            Destroy(targetedStructure);
            audioPlayer.PlayOneShot(targetedStructure.GetComponent<Struttura>().stats.explosionDestruction, targetedStructure.GetComponent<Struttura>().stats.volumeDistruzione);
        }
    }
}
