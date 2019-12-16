using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsplosioneProiettile : MonoBehaviour
{

    AudioSource audioPlayer;

    public GameController gm;
    public float aoeDamage = 1;
    public AudioClipTemplate clipExplosionGranade;
    public GameObject aoeExplosion;
    public float volumeEsplosione;

    List<GameObject> zombiesList = new List<GameObject>();

    void Start()
    {
        audioPlayer = GameObject.Find("SFX OneShot").GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Zombie")
        {
            zombiesList.Add(other.gameObject);
            audioPlayer.PlayOneShot(clipExplosionGranade.audio, clipExplosionGranade.volumeAudio);
        }
        if (other.tag == "Enviroment")
        {
            audioPlayer.PlayOneShot(clipExplosionGranade.audio, clipExplosionGranade.volumeAudio);
        }

    }

    public void DamageAll()
    {
        Instantiate(aoeExplosion, transform.position + (Vector3.up * 0.5f), transform.rotation);
        foreach (GameObject go in zombiesList)
        {
            go.GetComponent<ZombieStats>().hp -= aoeDamage;
            if (go.GetComponent<ZombieStats>().hp > 0)
                go.GetComponent<ZombieStats>().anim.BulletHit();
        }
    }
}
