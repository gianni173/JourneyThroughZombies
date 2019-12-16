using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterActivation : MonoBehaviour {

    public GameObject icon;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            icon.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            icon.SetActive(false);
        }
    }



}
