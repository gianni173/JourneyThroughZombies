using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "HUDTextsReferences", menuName = "SO_HUDTextsReferences")]
public class HUDTextsReferences : ScriptableObject
{

    public int scrapsReq = 0;
    public int foodReq = 0;
    public Sprite boostIcon;
    public string boostName;

}
