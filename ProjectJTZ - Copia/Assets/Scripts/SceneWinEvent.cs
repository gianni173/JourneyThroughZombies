using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneWinEvent : MonoBehaviour
{
    public SceneWinChecker script;
    public IntVariable sum;
    public int allSpawnsPossible;

    private void OnEnable()
    {
        sum.variable = allSpawnsPossible;
    }

    public void CheckSum()
    {
        if (sum.variable <= 0)
            script.enabled = true;
    }

}
