﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFood : MonoBehaviour {

    public SO_GameController gm;

    void Update()
    {

        gameObject.GetComponent<Text>().text = "" + gm.food;

    }
}
