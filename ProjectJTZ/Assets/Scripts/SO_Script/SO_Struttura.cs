using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Str_", menuName = "Struttura")]
public class SO_Struttura : ScriptableObject {

    public string buildingName;
    public int scrapsReq;
    public int foodReq;
    public Sprite icon;
    public Collider collider;
    public GameObject prefab;
    public AudioClip buildingSound;
    public AudioClip explosionDestruction;
    public float volumePiazzamento;
    public float volumeDistruzione;
    
    public float hp; //vita
    public float damageTimerInSec; //ogni quanto fa danno (filo spinato)
    public float damage; //danno

    public void CopyValues(SO_Struttura copyFrom, SO_Struttura copyTo)
    {
        copyTo.buildingName = copyFrom.buildingName;
        copyTo.scrapsReq = copyFrom.scrapsReq;
        copyTo.foodReq = copyFrom.foodReq;
        copyTo.icon = copyFrom.icon;
        copyTo.collider = copyFrom.collider;
        copyTo.prefab = copyFrom.prefab;
        copyTo.buildingSound = copyFrom.buildingSound;
        copyTo.hp = copyFrom.hp;
        copyTo.damageTimerInSec = copyFrom.damageTimerInSec;
        copyTo.damage = copyFrom.damage;
    }
}
