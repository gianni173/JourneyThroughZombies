using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrasitionMapGate : MonoBehaviour
{

    public Sprite brokenSprite;
    public AudioClip brokenGateSound;
    public float volumeSound = 1;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GameObject.Find("SFX OneShot").GetComponent<AudioSource>();
    }

    public void ChangeSprite()
    {
        StartCoroutine(ChangeSpriteAfter1Sec());
    }

    IEnumerator ChangeSpriteAfter1Sec()
    {
        yield return new WaitForSeconds(1.5f);
        GetComponent<SpriteRenderer>().sprite = brokenSprite;
        audioSource.PlayOneShot(brokenGateSound, volumeSound);
    }
}
