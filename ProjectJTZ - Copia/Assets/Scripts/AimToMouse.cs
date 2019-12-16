using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimToMouse : MonoBehaviour
{
    public GameController gm;
    public StatisticheShooting SO_stat;
    public Input SO_input;
    public IntVariable proiettiliSO;
    public AudioClipTemplate clipPistola;
    public AudioClipTemplate clipTorretta;

    AudioSource audioPlayer;
    Animator tor;
    Animator pla;
    float t = 0;
    bool stoRicaricando = false;
    bool uziPickedUp = false; 


    void Start()
    {
        audioPlayer = GameObject.Find("SFX OneShot").GetComponent<AudioSource>();
        tor = GameObject.Find("Torretta").GetComponent<Animator>();
        pla = GameObject.Find("PlayerOnCamper").GetComponent<Animator>();
    }

    void Update()
    {
        t += Time.deltaTime;

        //rotation
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(UnityEngine.Input.mousePosition.x, UnityEngine.Input.mousePosition.y, UnityEngine.Input.mousePosition.z));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000f))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
            if (gameObject.tag == "Player")
            {
                transform.Rotate(Vector3.right, 90);
                transform.Rotate(Vector3.forward, 90);
            }
            else
                transform.Rotate(Vector3.up, 90);
            //print(hit.point.x + " " + transform.position.y + " " + hit.point.z);
        }
        //shoot
        if (UnityEngine.Input.GetKey(SO_input.sparo) && ((gameObject.tag == "Player" || gm.ammo > 0)) && t > SO_stat.fireRate)
        {
            GameObject spawned;
            t = 0;
            //sul camper
            if (gameObject.tag == "Camper")
            {
                audioPlayer?.PlayOneShot(clipTorretta.audio, clipTorretta.volumeAudio);
                gm.ammo--;
                spawned = Instantiate(SO_stat.proiettile, transform.position + transform.right * -SO_stat.verticalOffsetShot + transform.forward * -SO_stat.horizOffsetShot, transform.rotation);
                spawned.transform.Rotate(Vector3.up, -90);
                spawned.transform.Rotate(Vector3.right, 90);
                spawned.transform.Rotate(Vector3.forward, 90);
                tor.SetBool("Shoot", true);
                pla.SetBool("it_shoot", true);
            }
            //a terra
            else if (gameObject.tag == "Player" && uziPickedUp)
            {
                if (!stoRicaricando)
                {
                    if (proiettiliSO.variable <= 0)
                    {
                        //ricarica
                        StartCoroutine(Ricarica());
                    }
                    else
                    {
                        //creazione proiettile e scelta offset
                        spawned = Instantiate(SO_stat.proiettile, transform.position + transform.right * SO_stat.verticalOffsetShot + transform.up * SO_stat.horizOffsetShot, transform.rotation);
                        spawned.transform.Rotate(Vector3.forward, -3);
                        proiettiliSO.variable--;
                        GetComponent<Animator>().SetBool("Shooting", true);
                        audioPlayer.PlayOneShot(clipPistola.audio, clipPistola.volumeAudio);
                    }
                }
            }
        }
        else
        {
            if (gm.mode == "ONGROUND")
            {
                GetComponent<Animator>().SetBool("Shooting", false);
            }
            tor.SetBool("Shoot", false);
            pla.SetBool("it_shoot", false);
        }
    }

    IEnumerator Ricarica()
    {
        audioPlayer.PlayOneShot(SO_stat.ricarica);
        stoRicaricando = true;
        yield return new WaitForSeconds(SO_stat.TempoRicarica);
        proiettiliSO.variable = SO_stat.CapienzaCaricatore;
        stoRicaricando = false;
    }

    public void PickUpUzi()
    {
        uziPickedUp = true;
    }
}
