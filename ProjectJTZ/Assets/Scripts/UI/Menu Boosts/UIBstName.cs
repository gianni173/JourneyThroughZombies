using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBstName : MonoBehaviour {

    public SO_HUDTextsReferences hudRef;
            
    void Update () {

        gameObject.GetComponent<Text>().text = hudRef.boostName;

    }
}
