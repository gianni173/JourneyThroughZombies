using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBstFoodReq : MonoBehaviour {

    public HUDTextsReferences hudRef;
            
    void Update () {

        gameObject.GetComponent<Text>().text = "-" + hudRef.foodReq;

    }
}
