using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PrintArrow : MonoBehaviour
{
    public GameController gm;
    public Input SO_input;
    public GameObject arrow;
    public float timer;
    bool pressed = false;

	void Start ()
    {
        arrow.SetActive(false);     
    }

    void Update()
    {
            if (UnityEngine.Input.GetKey(SO_input.puntatoreCamper) && gm.mode == "ONGROUND")
            {
            pressed = true;
                if (pressed)
                {
                StartCoroutine(CountDown());
                }
            }
            else if (gm.mode == "ONCAMPER")
            {

            arrow.SetActive(false);
            }
    }
    IEnumerator CountDown()
    {
        pressed = true;
        arrow.SetActive(true);
        yield return new WaitForSeconds(timer);
        arrow.SetActive(false);
        pressed = false;
    }

}
