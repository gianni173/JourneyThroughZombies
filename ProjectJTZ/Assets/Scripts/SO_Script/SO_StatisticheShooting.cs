using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatisticheShooting", menuName = "StatisticheShooting")]
public class SO_StatisticheShooting : ScriptableObject {

    public GameObject proiettile;
    public float horizOffsetShot;
    public float verticalOffsetShot;
    public float fireRate;
    public int CapienzaCaricatore;
    public int TempoRicarica;
    public AudioClip ricarica;
}
