﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Player : MonoBehaviour {

    public float MaxHealth { get; set; }
    public SO_GameController gm;
    public SO_GameController gmValues;
    public Slider healthBar;

	void Start ()
    {
        MaxHealth = gmValues.playerHp;

        healthBar.value = CalculationHealt();
	}

    void Update ()
    {
        healthBar.value = CalculationHealt();
    }

    float CalculationHealt()
    {      
        return gm.playerHp / MaxHealth;
    }
}