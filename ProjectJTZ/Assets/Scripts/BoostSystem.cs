using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSystem : MonoBehaviour
{
    public SO_IntVariable consumedScraps;
    public SO_IntVariable consumedFood;
    public SO_InventarioOggetti SO_boostsList;
    public SO_HUDTextsReferences hudRef;
    public SO_Input SO_input;
    public SO_GameController SO_gameManager;

    [HideInInspector]
    public SO_Boost selectedBoost;

    AudioSource audioSource;
    int index = 0;

    private void Start()
    {
        audioSource = GameObject.Find("SFX OneShot").GetComponent<AudioSource>();
    }

    void OnEnable ()
    {
        selectedBoost = SO_boostsList.ListaBoosts[index];
        NewBoost();
    }

	void Update ()
    {
        //scroll tra la lista di oggetti
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (index < SO_boostsList.ListaBoosts.Count - 1)
                index++;
            else
                index = 0;

            NewBoost();
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (index > 0)
                index--;
            else
                index = SO_boostsList.ListaBoosts.Count - 1;
            NewBoost();
        }

        if (Input.GetKeyDown(SO_input.utilizzoBoost) && 
            (selectedBoost.foodReq <= SO_gameManager.food && selectedBoost.scrapsReq <= SO_gameManager.scraps))
        {
            UtilizzaBoost();
        }
    }

    void NewBoost()
    {
        if (selectedBoost)
        {
            selectedBoost = SO_boostsList.ListaBoosts[index];
            hudRef.boostIcon = selectedBoost.icon;
            hudRef.foodReq = selectedBoost.foodReq;
            hudRef.scrapsReq = selectedBoost.scrapsReq;
            hudRef.boostName = selectedBoost.boostName;
        }
    }

    void UtilizzaBoost()
    {
        consumedScraps.variable = selectedBoost.scrapsReq;
        consumedFood.variable = selectedBoost.foodReq;
        audioSource.PlayOneShot(selectedBoost.boostSound, selectedBoost.soundScale);
        selectedBoost.effect.Activate();
        SO_gameManager.scraps -= selectedBoost.scrapsReq;
        SO_gameManager.food -= selectedBoost.foodReq;
    }
}
