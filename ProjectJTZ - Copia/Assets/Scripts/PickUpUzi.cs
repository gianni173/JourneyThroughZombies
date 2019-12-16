using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpUzi : MonoBehaviour
{

    public GameEvent PickUpUziEvent;
    public Input SO_input;
    public GameObject icon;

    bool pickUppable = false;

    private void Update()
    {
        if (pickUppable && UnityEngine.Input.GetKeyDown(SO_input.interazione))
        {
            PickUpUziEvent.Raise();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            pickUppable = true;
            icon.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            pickUppable = false;
            icon.SetActive(false);
        }
    }

}
