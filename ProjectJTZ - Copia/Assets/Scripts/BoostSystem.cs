using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSystem : MonoBehaviour
{
    public IntVariable consumedScraps;
    public IntVariable consumedFood;
    public InventarioOggetti SO_boostsList;
    public HUDTextsReferences hudRef;
    public Input SO_input;
    public GameController SO_gameManager;

    [HideInInspector]
    public Boost selectedBoost;

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
        if (UnityEngine.Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (index < SO_boostsList.ListaBoosts.Count - 1)
                index++;
            else
                index = 0;

            NewBoost();
        }

        if (UnityEngine.Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (index > 0)
                index--;
            else
                index = SO_boostsList.ListaBoosts.Count - 1;
            NewBoost();
        }

        if (UnityEngine.Input.GetKeyDown(SO_input.utilizzoBoost) && 
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
