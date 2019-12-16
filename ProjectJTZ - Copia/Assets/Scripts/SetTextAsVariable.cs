using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTextAsVariable : MonoBehaviour
{

    public IntVariable projectilesLoaded;

    private void Update()
    {
        GetComponent<Text>().text = "" + projectilesLoaded.variable;
    }

}
