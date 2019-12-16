using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameManager", menuName = "GameManager")]
public class SO_GameController : ScriptableObject
{

    public string mode = "ONGROUND";
    public string playerMode = "COMBAT";

    public int ammo = 100;
    public int scraps = 15;
    public int food = 15;

    public float playerHp = 100;
    public float camperFuel = 100;
    public float FuelConsumption = 0.1f;

    //public AudioClip pickUpAmmo;
    //public AudioClip pickUPScrap;
    //public AudioClip pickUpMeat;
    //public AudioClip pickUpFuel;
    //public AudioClip hit;
    //public AudioClip camperHit;
    //public AudioClip granade;
    public AudioClip Fiatone;
}
