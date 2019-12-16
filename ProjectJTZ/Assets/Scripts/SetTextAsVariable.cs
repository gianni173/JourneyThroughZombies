using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTextAsVariable : MonoBehaviour
{

    public SO_IntVariable projectilesLoaded;

    private void Update()
    {
        GetComponent<Text>().text = "" + projectilesLoaded.variable;
    }

}
