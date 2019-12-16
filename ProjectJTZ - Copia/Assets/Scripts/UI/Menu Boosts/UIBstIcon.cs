using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBstIcon : MonoBehaviour {

    public HUDTextsReferences hudRef;
            
    void Update () {

        gameObject.GetComponent<Image>().sprite = hudRef.boostIcon;

    }
}
