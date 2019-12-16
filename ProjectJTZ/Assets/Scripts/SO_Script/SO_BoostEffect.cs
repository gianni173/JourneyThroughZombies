using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BstEff_", menuName = "BoostEffect")]
public class SO_BoostEffect : ScriptableObject {

    public GameEvent boostEvent;

    public void Activate()
    {
        boostEvent.Raise();
    }

}
