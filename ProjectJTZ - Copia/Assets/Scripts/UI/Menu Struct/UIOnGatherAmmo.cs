﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOnGatherAmmo : MonoBehaviour {

    public SO_IntVariable ammoReference;

    void Update () {

        gameObject.GetComponent<Text>().text = "+" + ammoReference.variable;

    }
}
