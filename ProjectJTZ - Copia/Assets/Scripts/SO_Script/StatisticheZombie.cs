using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatisticheZombie", menuName = "StatisticheZombie")]
public class StatisticheZombie : ScriptableObject
{
    public float hp;
    public float speed;
    public float damage;
    public float attackTimerSec;
    public float ammoDropPercent;
    public bool isDropper = false;
    public int maxFocusSwitch;
    public bool striscia = false;

    public AudioClip arrotato;
}
