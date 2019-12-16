using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioClip", menuName = "SFX", order = 1)]
public class SO_AudioClip : ScriptableObject
{
	public AudioClip audio;
    public float volumeAudio;
}
