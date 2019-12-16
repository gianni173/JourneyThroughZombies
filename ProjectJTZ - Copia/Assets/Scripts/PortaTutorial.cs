using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaTutorial : MonoBehaviour
{
    AudioSource audioPlayer;
    SpriteRenderer sprite;
    bool canOpen = false;
    int i = 0;

    public Input so_Input;
    public List<Sprite> door = new List<Sprite>();
    public GameObject figlioPorta;
    public AudioClip apri;
    public AudioClip chiudi;
    public float volumeApri;
    public float volumeChiudi;
    public GameEvent CinematicaToCamper;

    bool cinematica = false;

	void Start ()
    {
        audioPlayer = GameObject.Find("SFX OneShot").GetComponent<AudioSource>();
        sprite = GetComponent<SpriteRenderer>();
	}
    private void Update()
    {
        if (UnityEngine.Input.GetKeyDown(so_Input.interazione) && canOpen)
        {
            if (i == 0)
            {
                if (!cinematica)
                {
                    CinematicaToCamper.Raise();
                    cinematica = true;
                }
                i++;
                sprite.sprite = door[i];
                figlioPorta.SetActive(false);
                audioPlayer.PlayOneShot(apri, volumeApri);
            }
            else
            {
                i--;
                sprite.sprite = door[i];
                figlioPorta.SetActive(true);
                audioPlayer.PlayOneShot(chiudi, volumeChiudi);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if ( other.tag == "Player")
        {
            canOpen = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canOpen = false;
        }
    }
}
