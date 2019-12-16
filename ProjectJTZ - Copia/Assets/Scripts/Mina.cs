using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mina : MonoBehaviour
{
    public GameController gm;
    public StructureTemplate SO_struttura;
    public AudioClipTemplate clipEsplosioneMina;
    public GameObject colliderExplo;


    AudioSource audioPlayer;
    List<GameObject> zombie = new List<GameObject>();
    List<GameObject> player = new List<GameObject>();
    Animator anim;

    float tempo;
    bool started = false;
    bool suonoAvviato = false;

    private void Start()
    {
        transform.position = new Vector3(transform.position.x, 0.05f, transform.position.z);
        audioPlayer = GameObject.Find("SFX OneShot").GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        tempo = SO_struttura.damageTimerInSec;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Zombie")
        {
            zombie.Add(other.gameObject);
            if(!started)
                StartCoroutine(CountDown());
        }
        if (other.tag == "Player")
        {
            player.Add(other.gameObject);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Zombie")
        {
            zombie.Remove(other.gameObject);
            if (zombie.Count == 0)
            {
                started = false;
                tempo = SO_struttura.damageTimerInSec;
            }
        }
        if (other.tag == "Player")
        {
            player.Remove(other.gameObject);
        }

    }
    IEnumerator CountDown()
    {
        started = true;
        while(started == true && tempo > 0) 
        {
            tempo -= Time.deltaTime;  
            if (tempo < 1f && !suonoAvviato)
            {
                ExplosionSound();
            }
            yield return null;
        }
               
        if (tempo <= 0)
        { 
            anim.SetBool("Explode",true);
            foreach(GameObject zom in zombie)
            {
                zom.GetComponent<ZombieStats>().hp -= (int)SO_struttura.damage;
            }
            if (player.Count > 0)
            {
                gm.playerHp -= SO_struttura.damage;
            }
        }
        started = false;
    }

    public void DestroyMine()
    {
        Destroy(gameObject);
    }

    public void ExplosionSound()
    {
        audioPlayer.PlayOneShot(clipEsplosioneMina.audio, clipEsplosioneMina.volumeAudio);
        suonoAvviato = true;
    }

    public void ActivateMineCollider()
    {
        Destroy(GetComponent<Struttura>());
        colliderExplo.SetActive(true);
    }
}
