using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScraps : MonoBehaviour {

    public GameController gm;

    void Update()
    {

        gameObject.GetComponent<Text>().text = "" + gm.scraps;

    }
}
