using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIammo : MonoBehaviour {

    public GameController gm;

    void Update () {

        gameObject.GetComponent<Text>().text = "" + gm.ammo;

    }
}
