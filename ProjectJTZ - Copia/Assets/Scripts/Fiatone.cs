using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fiatone : MonoBehaviour
{
    public SO_StatistichePlayer stat_player;

    AudioSource audioPlayer;
    float maxVolume;

	void Start ()
    {
        audioPlayer = GetComponent<AudioSource>();
        maxVolume = stat_player.stamina;
	}
	
	void Update ()
    {
        CalculateVolume();
	}

    void CalculateVolume()
    {
        audioPlayer.volume = 1f - (stat_player.stamina / maxVolume);
    }
}
