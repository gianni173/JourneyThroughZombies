﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOnGatherFood : MonoBehaviour {

    public SO_IntVariable foodReference;

    void Update () {

        gameObject.GetComponent<Text>().text = "+" + foodReference.variable;

    }
}
