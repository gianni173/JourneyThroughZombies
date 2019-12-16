using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPackPickUp : MonoBehaviour {

    public GameController gm;
    public IntVariable SO_intVariable;
    public GameEvent AmmoPickUpEvent;
    public AudioClipTemplate clipPickUpAmmo;
    public int maxDrop = 20;
    public int minDrop = 10;

    AudioSource audioPlayer;
    
    private void Start()
    {
        audioPlayer = GameObject.Find("SFX OneShot").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            int value = Random.Range(minDrop, maxDrop+1);
            audioPlayer.PlayOneShot(clipPickUpAmmo.audio, clipPickUpAmmo.volumeAudio);
            gm.ammo += value;
            SO_intVariable.variable = value;
            AmmoPickUpEvent.Raise();
            Destroy(gameObject);
        }
    }
}
