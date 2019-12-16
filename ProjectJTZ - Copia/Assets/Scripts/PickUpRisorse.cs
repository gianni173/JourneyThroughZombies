using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpRisorse : MonoBehaviour
{
    public enum Risorsa
    {
        Scrap,
        Carne,
        Fuel,
    }

    [HideInInspector]
    public int quantity = 0;
    [HideInInspector]
    public int spawnRemained = 0;
    [HideInInspector]
    public int maxSpawns = 0;

    public SO_IntVariable OnGatherScrapsVar;
    public SO_IntVariable OnGatherFoodVar;
    public GameEvent OnGatherScrapsEvent;
    public GameEvent OnGatherFoodEvent;
    public GameObject pickUpTextPrefab;
    public SO_GameController SO_gm;
    public Risorsa risorsa = Risorsa.Scrap;
    public SO_AudioClip clipScraps;
    public SO_AudioClip clipMeat;
    public SO_AudioClip clipFuel;
    public GameEvent tutorialEndEvent;
    public SO_BoolVariable tutorialTrigger;

    AudioSource audioPlayer;

    private void Start()
    {
        audioPlayer = GameObject.Find("SFX OneShot").GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (risorsa == Risorsa.Fuel && SO_gm.camperFuel == 100)
                return;

            GameObject spawnedText;
            spawnedText = Instantiate(pickUpTextPrefab, transform.position += Vector3.up * 2, transform.rotation);
            ResPickUpText text = spawnedText.GetComponent<ResPickUpText>();
            if (risorsa == Risorsa.Scrap)
            {
                OnGatherScrapsVar.variable = quantity;
                OnGatherScrapsEvent.Raise();
                audioPlayer.PlayOneShot(clipScraps.audio, clipScraps.volumeAudio);
                SO_gm.scraps += quantity;
            }
            else if (risorsa == Risorsa.Carne)
            {
                OnGatherFoodVar.variable = quantity;
                OnGatherFoodEvent.Raise();
                audioPlayer.PlayOneShot(clipMeat.audio, clipMeat.volumeAudio);
                SO_gm.food += quantity;
            }
            else if (risorsa == Risorsa.Fuel)
            {
                audioPlayer.PlayOneShot(clipFuel.audio, clipFuel.volumeAudio);
                SO_gm.camperFuel += quantity;
                if (SO_gm.camperFuel >= 100)
                    SO_gm.camperFuel = 100;

                if (SO_gm.camperFuel >= 25 && !tutorialTrigger.variable)
                {
                    tutorialTrigger.variable = true;
                    tutorialEndEvent.Raise();
                }
            }
            
            text.textShowed = spawnRemained + " / " + maxSpawns;

            Destroy(gameObject);
        }
    }
}
