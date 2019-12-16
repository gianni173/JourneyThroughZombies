using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healt_Camper : MonoBehaviour
{
    private float MaxHealth { get; set; }
    public SO_GameController gm;
    public SO_GameController gmValues;
    public Slider healthBar;
    GameObject camperHull;

    private void Awake()
    {
        camperHull = GameObject.Find("CamperHull");
        
    }
    void Start()
    {
        camperHull.GetComponent<Animator>().enabled = false;
        MaxHealth = gmValues.camperFuel;

        healthBar.value = CalculationHealt();
    }

    void Update()
    {
        healthBar.value = CalculationHealt();
    }

    float CalculationHealt()
    {

        return gm.camperFuel / MaxHealth;
    }
}
