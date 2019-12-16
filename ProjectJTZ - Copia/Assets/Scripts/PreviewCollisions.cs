using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewCollisions : MonoBehaviour {

    //[HideInInspector]
	public int collidingThings = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Player" && other.tag != "Ground")
            collidingThings++;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player" && other.tag != "Ground")
            collidingThings--;
    }
}
