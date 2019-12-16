using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTextResPickup : MonoBehaviour {

    public ResPickUpText fatherScript;

    private void Update()
    {
        GetComponent<TextMesh>().text = fatherScript.textShowed;
    }

}
