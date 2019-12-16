using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameManager", menuName = "GameManager")]
public class GameController : ScriptableObject
{

    public string mode = "ONGROUND";
    public string playerMode = "COMBAT";

    public int ammo = 100;
    public int scraps = 15;
    public int food = 15;

    public float playerHp = 100;
    public float camperFuel = 100;
    public float FuelConsumption = 0.1f;

    public AudioClip Fiatone;
}
