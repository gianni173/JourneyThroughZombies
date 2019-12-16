using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOnGatherScraps : MonoBehaviour {

    public SO_IntVariable scrapsReference;

    void Update () {

        gameObject.GetComponent<Text>().text = "+" + scrapsReference.variable;

    }
}
