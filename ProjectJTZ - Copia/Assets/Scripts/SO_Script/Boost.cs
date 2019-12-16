using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bst_", menuName = "Boost")]
public class Boost : ScriptableObject {

    public string boostName;
    public int scrapsReq;
    public int foodReq;
    public Sprite icon;
    public BoostEffect effect;
    public AudioClip boostSound;
    public float soundScale = 1;
}
