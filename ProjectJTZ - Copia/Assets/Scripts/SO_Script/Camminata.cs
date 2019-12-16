using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SFX_Walk", menuName = "SoundsWalk", order = 1)]
public class Camminata : ScriptableObject
{
    public List<AudioClip> Passi;

    public float soundScale = 1;

}
