using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOnGatherScraps : MonoBehaviour {

    public IntVariable scrapsReference;

    void Update () {

        gameObject.GetComponent<Text>().text = "+" + scrapsReference.variable;

    }
}
