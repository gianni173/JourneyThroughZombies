using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSound : MonoBehaviour
{
    public SO_Camminata clip;
    AudioSource audioPlayer;
    int i = 0;
	void Start ()
    {
        audioPlayer = GameObject.Find("SFX OneShot").GetComponent<AudioSource>();
	}
    
    public void Passo()
    {
        i = Random.Range(0, clip.Passi.Count);
        audioPlayer.PlayOneShot(clip.Passi[i], clip.soundScale);
    }

}
